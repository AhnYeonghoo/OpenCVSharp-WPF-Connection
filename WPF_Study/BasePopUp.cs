using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace WPF_Study
{

    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractControlDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        { }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(TAbstract)) return typeof(TBase);
            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(TAbstract)) objectType = typeof(TBase);
            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }

    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BasePopUp, Window>))]
    public abstract class BasePopUp : Window, INotifyPropertyChanged
    {
        public BasePopUp()
        {
            Topmost = true;
            DataContext = true;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.None;
            IsVisibleChanged += BasePopUp_IsVisibleChanged;
        }

        public string UnitID { get; set; }

        private void BasePopUp_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (this != null && this.Visibility == System.Windows.Visibility.Visible)
                VisibleChanged();
        }

        public abstract void VisibleChanged();

        protected void SetCenterPosition()
        {
            double primScreenHeight = System.Windows.SystemParameters.FullPrimaryScreenHeight;
            double primScreenWidth = System.Windows.SystemParameters.FullPrimaryScreenWidth;
            Top = (primScreenHeight - this.Height) / 2;
            Left = (primScreenWidth - this.Width) / 2;
        }

        public delegate void OnLogWriteHandler(LogTypes type, string unitID, string content);
        public static event OnLogWriteHandler OnLogWrite;
        public void LogWrite(LogTypes type, string unitID, string content) => OnLogWrite?.Invoke(type, unitID, content);
        public void LogWrite(LogTypes type, string unitID, Exception ex) => OnLogWrite?.Invoke(type, unitID, ex.ToString());
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Windows Setting
        private System.Windows.Point startPos;
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        static extern int TrackPopupMenu(IntPtr hMenu, uint uFlags, int x, int y, int nReserved, IntPtr hWnd, IntPtr prcRect);
        #endregion


    }

    public enum LogTypes
    {
        Normal,
        Error,
        Debug,
        Warning
    }
}
