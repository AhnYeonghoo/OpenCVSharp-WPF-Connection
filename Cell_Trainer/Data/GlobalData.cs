using System;
using System.Collections.Generic;
using OpenCvSharp;
using Cell_Trainer.Data.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Trainer.Data
{
    public static class GlobalData
    {
        static GlobalData()
        {
            Categories.Add(new Data.Model.Category("Background", new Scalar(0, 0, 0), 0));
            Categories.Add(new Data.Model.Category("Cathode", new Scalar(0, 0, 255), 0));
            Categories.Add(new Data.Model.Category("Anode", new Scalar(0, 255, 0), 2));
            Categories.Add(new Data.Model.Category("Cathode2", new Scalar(0, 0, 255), 1));
        }
        public enum EnumDrawMode
        {
            Polygon,
            Line,
        }

        public static List<Category> Categories = new List<Category>();
        public static Category CurrentCategory = new Category();
        public static EnumDrawMode CurrentDrawMode = EnumDrawMode.Line;
        private static int opacity;

        public static int Opacity
        {
            set
            {
                opacity = Math.Max(0, Math.Min(100, value));
            }
            get => opacity;
        }
    }
}
