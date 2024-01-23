using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Trainer.Data.IO
{
    public static class FileHelper
    {
        public static List<string> LoadFiles(string title = null, bool multi_select = false, string[] exts = null)
        {
            List<string> rets = new List<string>();

            if (title is null)
            {
                title = "Select file(s) what you want";
            }

            System.Windows.Forms.OpenFileDialog dialog;
        }
    }
}
