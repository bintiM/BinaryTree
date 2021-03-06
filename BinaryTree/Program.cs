﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryTree bt = new BinaryTree();

            bt.add(new Node(1), null);
            bt.add(new Node(9), bt.root);
            bt.add(new Node(5), bt.root);
            bt.add(new Node(3), bt.root);
            bt.add(new Node(1), bt.root);
            bt.add(new Node(7), bt.root);

            Console.WriteLine("Traversierungen");

            Console.WriteLine("PreOrder:");
            bt.printPreOrder();
            Console.WriteLine("\n*********************************");

            Console.WriteLine("InOrder");
            bt.printInOrder();
            Console.WriteLine("\n*********************************");

            Console.WriteLine("PostOrder");
            bt.printPostOrder();
            Console.WriteLine("\n*********************************");

            Console.WriteLine("Max:");
            bt.max();
            Console.WriteLine("*********************************");

            Console.WriteLine("Min:");
            bt.min();
            Console.WriteLine("*********************************");



            #region Vergleiche
            int max = 5000000;

            Console.WriteLine("\nVergleich zwischen Array und BinaryTree Suche mit " + max + " Elementen...");

            Stopwatch sW = new Stopwatch();
            sW.Start();
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.addInt(0);

            int[] intArray = new int[max];
            intArray[0] = 0;

            Random r = new Random();
            

            for (int i = 1; i < max; i++)
            {
                // Zufallszahl erzeugen
                int c = r.Next(0, max);

                //beim Binärbaum hinzufügen
                binaryTree.addInt(c);

                // im Array einfügen
                intArray[i] = c;

            }



            sW.Stop();
            Console.WriteLine("habe fertig nach :\t\t" + sW.Elapsed);

            //zu suchende Zahl per Zufall ausgewählt
            int search = intArray[r.Next(0, max)];

            Console.WriteLine("Suche nach: " + search);
            //Array Suche
            sW.Restart();
            int stepsArray = 0;
            for (int i = 0; i < max; i++)
            {
                if (intArray[i] == search)
                    break;
                stepsArray++;
            }
            
            sW.Stop();
            Console.WriteLine("gefunden:" + intArray[stepsArray]);
            Console.WriteLine("Array: \t\t" + stepsArray + " Schritte \t" + sW.Elapsed);

            //Binary Suche
            sW.Restart();
            int stepsBT = binaryTree.searchInt(search);
            sW.Stop();
            Console.WriteLine("Binärbaum: \t" + stepsBT + " Schritte \t" + sW.Elapsed);



            #endregion

            Console.ReadKey();
        }
    }
}
