using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eigth_Laba
{
    internal interface IView
    {
        string GetMainPath();
        string GetSecondaryPath();
        event EventHandler<EventArgs> Connect;
        event EventHandler<EventArgs> Synchronize;
    }
}
