using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using log4net;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace WPF_Study
{
    /// <summary>
    /// PagelogViewer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PagelogViewer :  UserControl, IPage
    {
        private object _obLock = new object();
        private static ILog _log4net = LogManager.GetLogger(typeof(App));

        private DateTime _dtDeleteOldFile = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
        private TimeSpan _maxAgeRollBackups = new TimeSpan(50, 0, 0, 0);
        public PagelogViewer()
        {
            InitializeComponent();

            BaseLogUnit.OnLogWrite += BaseLogUnit_OnLogWrite;
            BasePopUp.OnLogWrite += BasePopUp_OnLogWrite;
        }

        private void BasePopUp_OnLogWrite(LogTypes type, string unitID, string content)
        {
            LogWrite(type, unitID, content);
        }

        private void BaseLogUnit_OnLogWrite(LogTypes type, string unitID, string content)
        {
            LogWrite(type, unitID, content);
        }

        public bool Enter()
        {
            return true;
        }

        public bool Exit()
        {
            return true;
        }

        public void LogWrite(LogTypes logType, string unit, string content)
        {
            content = content.Replace(",", ",");
            content = content.Replace("\r\n", "\r\n,,");

            try
            {
                lock (_obLock)
                {
                    DeleteOldFile();
                    string time = DateTime.Now.ToString(ConstMainWindow.STR_LOGVIEWER_TIME_FORMAT);
                    if (logType != LogTypes.Debug)
                    {
                        OutputMessage(time, logType, unit, content);
                    }
                    string strLogMsg = string.Format("{0},{1},{2},{3}", time, logType.ToString(), unit, content);
                    switch (logType)
                    {
                        case LogTypes.Normal:
                            _log4net.Info(strLogMsg);
                            break;
                        case LogTypes.Error:
                            GPage.MainWindow.RefreshWarningPopUp(unit, content);
                            break;
                        case LogTypes.Debug:
                            _log4net.Debug(strLogMsg);
                            break;
                        case LogTypes.Warning:
                            _log4net.Warn(strLogMsg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                GPage.MainWindow.RefreshWarningPopUp(unit, ex.ToString());
            }
        }

        private void DeleteOldFile()
        {
            if (_dtDeleteOldFile.Date != DateTime.Now.Date)
            {
                _dtDeleteOldFile = DateTime.Now;
                var checkTime = DateTime.Now.Subtract(_maxAgeRollBackups);
                foreach (string file in Directory.GetFiles(GSystem.LogPath, "*.csv"))
                {
                    if (System.IO.File.GetLastWriteTime(file) < checkTime)
                        System.IO.File.Delete(file);
                }
            }
        }

        private void OutputMessage(string time, LogTypes logType, string unit, string content)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                LogItem item = new LogItem() { LogTime = time, LogType = logType.ToString(), Unit = unit, Content = content };
                this.LogListView.Items.Add(item);
                while (this.LogListView.Items.Count > 200)
                    this.LogListView.Items.RemoveAt(0);

                this.LogListView.Items.MoveCurrentToLast();
                this.LogListView.ScrollIntoView(this.LogListView.Items.CurrentItem);
            }));
        }

        public SolidColorBrush GetColor(LogTypes Type)
        {
            switch (Type)
            {
                case LogTypes.Debug: return Brushes.Blue;
                case LogTypes.Normal: return Brushes.Black;
                case LogTypes.Error: return Brushes.Red;
                case LogTypes.Warning: return Brushes.Green;
                default: return Brushes.Black;
            }
        }

        private void LogListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (LogItem)this.LogListView.SelectedItem;
            if (item != null)
            {
                this.tbTime.Text = string.Format("Time : {0}", item.LogTime);
                this.tbType.Text = string.Format("Type : {0}", item.LogType);
                this.tbUnit.Text = string.Format("Unit : {0}", item.Unit);
                this.tbContent.Text = string.Format("Content : {0}", item.Content);
            }
        }
    }

    public class LogItem
    {
        public string LogTime { get; set; }
        public string LogType { get; set; }
        public string Unit { get; set; }
        public string Content { get; set; }
    }
}
