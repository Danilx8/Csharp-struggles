using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninth_Laba
{
    interface IView
    {
        string GetMainPath();
        string GetSecondaryPath();
        void ShowResult(Syncronizations Result);
        void Connected(bool Success);
        event EventHandler<EventArgs> Synchronize;
    }
}
