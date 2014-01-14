using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    //this is my node (string based can be generic thats for latter)
    public class Node
    {

        public int Data { get; set; }

        //prop
        public Node Left { get; set; }
        public Node Right { get; set; }


        //ctor
        public Node()
        {

        }

        public Node(int item)
        {
            Data = item;
        }

        public void Insert(int data)
        {
        }


        public void Remove(int data)
        {
        }

        public void displayTree()
        {


            if (this == null)
                return;

            if (Left != null)
            {
                Left.displayTree();
            }
            System.Console.Write(Data + " ");
            if (Right != null)
            {
                Right.displayTree();
            }


        }

        public void insertNode(Node root, Node newNode)
        {
            Node temp;
            temp = root;

            if (newNode.Data < temp.Data)
            {
                if (temp.Left == null)
                {
                    temp.Left = newNode;

                }

                else
                {
                    temp = temp.Left;
                    insertNode(temp, newNode);

                }
            }
            else if (newNode.Data > temp.Data)
            {
                if (temp.Right == null)
                {
                    temp.Right = newNode;

                }

                else
                {
                    temp = temp.Right;
                    insertNode(temp, newNode);
                }
            }
        }


    }
}
