using System;
using System.Collections;
using System.Collections.Generic; 

namespace Seventh_Laba
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTree<T> Parent, Left, Right;
        private T Value;

        public BinaryTree(T value, BinaryTree<T> parent)
        {
            Value = value;
            Parent = parent;
        }

        public void Add(T value)
        {
            if (value.CompareTo(this.Value) < 0)
            {
                if (Left == null)
                {
                    Left = new BinaryTree<T>(value, this);
                }
                else
                {
                    Left?.Add(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinaryTree<T>(value, this);
                }
                else
                {
                    Right?.Add(value);
                }
            }
        }

        public BinaryTree<T> Current() => this;

        public BinaryTree<T> Next()
        {
            if (Left != null)
            {
                return Left;
            } else if (Right != null)
            {
                return Right;
            }
            else
            {
                BinaryTree<T> CurrentElement = this;
                BinaryTree<T> RightNeighbour = Parent.Right;
                return DeadEndNext(CurrentElement, RightNeighbour);
            } 
        }

        private BinaryTree<T> DeadEndNext(BinaryTree<T> CurrentElement, BinaryTree<T> RightNeighbour)
        {
            if (CurrentElement == RightNeighbour)
            {
                return DeadEndNext(RightNeighbour, RightNeighbour.Parent.Right);
            } else
            {
                return RightNeighbour;
            }
        }

        public BinaryTree<T> Previous() => Parent; 

        public static BinaryTree<T> operator ++(BinaryTree<T> CurrentNode)
        {
            return CurrentNode.Next();
        }

        public static BinaryTree<T> operator --(BinaryTree<T> CurrentNode)
        {
            return CurrentNode.Previous();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Left != null)
            {
                foreach (var item in Left)
                {   
                    yield return item;
                }
            }

            yield return Value;

            if (Right != null)
            {
                foreach (var item in Right)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (Left != null)
            {
                foreach (var item in Left)
                {
                    yield return item;
                }
            }

            yield return Value;

            if (Right != null)
            {
                foreach (var item in Right)
                {
                    yield return item;
                }
            }
        }
    }
}
