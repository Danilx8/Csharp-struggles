using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eigth_Laba
{
    interface IView
    {
        string GetMainPath();
        string GetSecondaryPath();
        void ShowResult(Dictionary<int, string[]> Result);
        void Connected(bool Success);
        event EventHandler<EventArgs> Synchronize;
    }
}
