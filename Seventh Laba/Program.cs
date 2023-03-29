using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Seventh_Laba
{
    internal class Program
    {
        delegate List<int> InOrderTraversal(BinaryTree<int> Tree);
        delegate void AscendingBinaryTree(BinaryTree<int> Tree);
        delegate void DescendingBinaryTree(BinaryTree<int> Tree);
        static void Main(string[] args)
        {
            int NodesAmount = 10;
            int MaximumValue = 100;
            Random Randomizer = new Random();

            BinaryTree<int> Tree = new BinaryTree<int>(Randomizer.Next(MaximumValue), null);
            for (int NodeIndex = 0; NodeIndex < NodesAmount; ++NodeIndex)
            {
                Tree.Add(Randomizer.Next(MaximumValue));
            }

            InOrderTraversal ListerLambda = (LambdaTree) =>
            {
                List<int> Nodes = new List<int>();
                foreach (int Node in LambdaTree)
                {
                    Nodes.Add(Node);
                }
                return Nodes;
            };

            AscendingBinaryTree AscendingList = (LambdaTree) =>
            {
                List<int> Nodes = ListerLambda(LambdaTree);
                Nodes.Sort();
                for (int NodeIndex = 0; NodeIndex <= NodesAmount; ++NodeIndex)
                {
                    Console.WriteLine(Nodes[NodeIndex]);
                }
            };

            DescendingBinaryTree DescendingList = (LambdaTree) =>
            {
                List<int> Nodes = ListerLambda(LambdaTree);
                Nodes.Sort();
                Nodes.Reverse();
                for (int NodeIndex = 0; NodeIndex <= NodesAmount; ++NodeIndex)
                {
                    Console.WriteLine(Nodes[NodeIndex]);
                }
            };

            Console.WriteLine("Ветви древа в порядке возрастания:");
            AscendingList(Tree);
            Console.WriteLine();
            Console.WriteLine("Ветви древа в порядке убывания:");
            DescendingList(Tree);
            Console.ReadKey();
        }
    }
}
