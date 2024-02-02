using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Study
{
    public interface IPage
    {
        bool Enter();
        bool Exit();
    }
}
