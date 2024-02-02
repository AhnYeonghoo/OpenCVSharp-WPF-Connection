using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Study
{
    public abstract class BaseLogUnit
    {
        public string UnitID { get; set; }

        public BaseLogUnit()
        {
            UnitID = GetType().Name;
        }

        public delegate void OnLogWriteHandler(LogTypes type, string unitID, string content);
        public static event OnLogWriteHandler OnLogWrite;

        public void LogWrite(LogTypes type, string unitID, string content) => OnLogWrite?.Invoke(type, unitID, content);
        public void LogWrite(LogTypes type, string unitID, Exception ex) => OnLogWrite?.Invoke(type, unitID, ex.ToString());
    }
}
