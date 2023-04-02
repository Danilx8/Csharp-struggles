using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eigth_Laba
{
    internal class Presenter
    {
        private Model model;

        public Presenter(string MainFolderPath, string SecondaryFolderPath)
        {
            model = new Model(MainFolderPath, SecondaryFolderPath);
        }

        public bool BootSynchronization(object sender, EventArgs e)
        {
            return (model.Synchronize());
        }

        public Dictionary<int, string[]> PassStates(object sender, EventArgs e)
        {
            return model.CheckStates();
        }
    }
}
