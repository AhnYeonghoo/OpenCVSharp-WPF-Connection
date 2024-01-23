using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Trainer.Data.Model
{
    public class Category
    {
        public Category()  { }

        public Category(string name, Scalar color, int index) : this()
        {
            Name = name;
            Color = color;
            Index = index;
        }

        public Scalar Color = new Scalar();
        public string Name = "";
        public int Index = 0;
    }
}
