using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System.Windows.Threading;

namespace OpenCVSharp
{
    /// <summary>
    /// Interaction logic for SizeRefac.xaml
    /// </summary>
    public partial class SizeRefac : System.Windows.Window
    {
        VideoCapture cam;
        Mat frame;
        DispatcherTimer timer;
        bool isInitCam, isInitTimer;

        public SizeRefac()
        {
            //Mat src = new Mat("PaperAirplane.webp");
            //Mat dst = new Mat();
            //image1.Source = OpenCvSharp.WpfExtensions.WriteableBitmapConverter.ToWriteableBitmap(src);
            //Cv2.Resize(src, dst, new OpenCvSharp.Size(500, 250));

            //image1.Source = OpenCvSharp.WpfExtensions.WriteableBitmapConverter.ToWriteableBitmap(src);
            //image2.Source = OpenCvSharp.WpfExtensions.WriteableBitmapConverter.ToWriteableBitmap(dst);
            //Cv2.WaitKey(0);
            InitializeComponent();
        }

        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            isInitCam = InitCamera();
            isInitTimer = InitTimer(0.01);
            if (isInitCam && isInitTimer) timer.Start();
        }

        private bool InitTimer(double intervalMs)
        {
            try
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(intervalMs);
                timer.Tick += new EventHandler(TimerTick);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool InitCamera()
        {
            try
            {
                cam = new VideoCapture(0);
                cam.FrameHeight = (int)Cam_1.Height;
                cam.FrameWidth = (int)Cam_1.Width;
                frame = new Mat();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            cam.Read(frame);
            Cam_1.Source = OpenCvSharp
                            .WpfExtensions
                            .WriteableBitmapConverter
                            .ToWriteableBitmap(frame);
        }

      
            
     
    }
}
