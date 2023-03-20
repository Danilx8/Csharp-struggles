using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifth_Laba
{
    internal class Director
    {
        private IStringBuilder StringBuilder;
        public Director() { }
        
        public void SetBuilder(IStringBuilder StringBuilder)
        {
            this.StringBuilder = StringBuilder;
        }

        public void FixDocument(string FilePath)
        {
            StringBuilder.CreateInstance();
            StringBuilder.CreateMask();
            StringBuilder.Correct(FilePath);
        }
    }
}
