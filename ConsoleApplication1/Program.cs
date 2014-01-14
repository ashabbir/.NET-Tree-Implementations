using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class Program
    {

        static Node tree;

        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                   
                    tree = CreateTree();
                    tree.displayTree();
                    Console.WriteLine(line);

                   

                    //split line 
                    var values = line.Split(' ');
                    if (values.Length != 2)
                    {
                        Console.WriteLine("Incorrect input: try again");
                    }
                    else
                    {
                        int _left;
                        int.TryParse(values[0], out _left);
                        int _right;
                        int.TryParse(values[1], out _right);

                        var _leastCommon = FindLowestCommon(_left, _right);

                        if (_leastCommon == 0)
                        {
                            Console.WriteLine("not found");
                        }
                        else
                        {
                            Console.WriteLine(_leastCommon);
                        }

                    }



                }
        }


        //this will create the tree
        public static Node CreateTree()
        {

            #region hard coded tree
            //Creating the Nodes for the Tree
            //starting from the bottom most nodes 

            ////3 --> 1 and 29
            //Node level3 = new Node(3)
            //{
            //    Left = new Node(1),
            //    Right = new Node(29)
            //};

            ////8 --> 3(level3) and 20
            //Node level2 = new Node(8)
            //{
            //    Left = level3,
            //    Right = new Node(20)
            //};

            ////30 --> level2 and 52
            //Node Final = new Node(30)
            //{
            //    Left = level2,
            //    Right = new Node(52)
            //};
            #endregion

            var toReturn = new Node(3);

            toReturn.insertNode(toReturn, new Node(30));
            toReturn.insertNode(toReturn, new Node(8));
            toReturn.insertNode(toReturn, new Node(20));
            toReturn.insertNode(toReturn, new Node(1));
            toReturn.insertNode(toReturn, new Node(29));
            toReturn.insertNode(toReturn, new Node(52));
            return toReturn;
        }



        public static int FindLowestCommon(int _left, int _right)
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            
            Node temp = CreateTree();

            //add root
            leftList.Add(temp.Data);
            rightList.Add(temp.Data);

            while (temp != null && temp.Data != _left)
            {
                if (temp.Data < _left)
                    temp = temp.Right;
                else
                    temp = temp.Left;

                if (temp != null)
                {
                    leftList.Add(temp.Data);
                }

            }

            temp = CreateTree();
            while (temp != null && temp.Data != _right)
            {
                if (temp.Data < _right)
                    temp = temp.Right;
                else
                    temp = temp.Left;
                if (temp != null)
                {
                    rightList.Add(temp.Data);
                }
            }

            var toReturn = 0;
            foreach (var leftitem in rightList)
            {
                foreach (var rightitem in leftList)
                {
                    if (leftitem == rightitem)
                    {
                        toReturn = leftitem;
                    }
                }
            }


            return toReturn;
        }



    }


}
