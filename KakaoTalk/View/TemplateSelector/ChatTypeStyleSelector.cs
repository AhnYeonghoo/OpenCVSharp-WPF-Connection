using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Common.Enums;

namespace Views.TemplateSelector
{ 
    public class ChatTypeStyleSelector : DataTemplateSelector
    {
        public ChatTypeStyleSelector() { }
        public DataTemplate NormalTemplate { get; set; }
        public DateTemplate PhotoTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return NormalTemplate;
        }
    }
}
