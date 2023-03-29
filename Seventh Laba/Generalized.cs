using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Seventh_Laba
{
    class Generalized<T>: IEnumerable<T>
    {
        private Collection<T> TreeNodes;
        private ParameterExpression Value = Expression.Parameter(typeof(T));
        private int CurrentIndex = -1;
        
        public void AppendParameters(T NewNode)
        {
            TreeNodes.Add(NewNode);
        }

        private T Current(int PassedIndex) => TreeNodes[PassedIndex];

        private T Next()
        {
            if (CurrentIndex == 0)
            {
                throw new Exception("Выход за границы коллекции");
            } else if (CurrentIndex == -1)
            {
                CurrentIndex = TreeNodes.Count - 2;
                return Current(TreeNodes.Count - 1);
            } else
            {
                return Current(CurrentIndex--);
            }
        }

        private T Previous()
        {
            if (CurrentIndex == -1 || CurrentIndex == TreeNodes.Count - 1)
            {
                throw new Exception("Выход за границы коллекции");
            } else 
            {
                return Current(CurrentIndex++);
            } 
        }

        public IEnumerator<T> GetEnumerator()
        {
            return TreeNodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
