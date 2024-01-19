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
using System.Threading;

using OpenCvSharp;

namespace OpenCVSharp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : System.Windows.Window
    {
        private VideoCapture capVideo;
        private VideoCapture capCamera;

        int sleepTime;

        Mat matImage = new Mat();

        public Window1()
        {
            InitializeComponent();
            InitializeVideo();
            InitializeCamera();
        }

        private void InitializeCamera()
        {
            capCamera = new VideoCapture(0);
        }

        private void InitializeVideo()
        {
            string filePath = $"Empty";
            capVideo = new VideoCapture(filePath);
            sleepTime = (int)Math.Round(1000 / capVideo.Fps);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
           
        }    

        

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (capVideo.IsOpened())
            {
                capVideo.Dispose();
            }
        }

        
    }
}
