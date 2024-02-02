using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Study
{
    public class GPage 
    {
        public static GPage Instance;
        public static Dictionary<string, UserControl> Controls { get; set; } = new Dictionary<string, UserControl>();
        public static T GetControl<T>() where T : class
        {
            if (!Controls.ContainsKey(typeof(T).Name))
                return null;
            return Controls[typeof(T).Name] as T;
        }

        static GPage()
        {
            
        }
    }
}
