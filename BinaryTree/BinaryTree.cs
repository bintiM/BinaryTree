using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTree
    {
        private Node _root;

        //speichert den root node (Wurzel)
        public Node root
        {
            get { return _root; }
            set { _root = value; }
        }

        // zählen der Schritte für Suche im Tree
        int steps = 0;

        //hinzufügen eines neuen Knoten im BinaryTree
        public void add(Node newNode, Node currNode)
        {
            if(_root == null) // wenn noch kein root vorhanden, setze neuen root
            {
                _root = newNode;
                return;
            }
            if(newNode.data > currNode.data) // wenn der Wert des neuen Knotens größer ist, als der derzeit betrachtete Knoten, dann füge ihn als neuen rechten Knoten ein, falls dort noch keiner ist
            {
                if (currNode.right == null)
                    currNode.right = newNode;
                else
                    add(newNode, currNode.right); // ein Knoten ist rechts schon vorhanden, führe die Methode rekursiv aus
            }
            else
            {
                if (currNode.left == null) // neuer Knoten ist kleiner und soll links hinzugefügt werden
                    currNode.left = newNode;
                else
                    add(newNode, currNode.left); // linker Platz ist nicht leer, daher ruft sich die Methode selbst auf mit dem derzeiten linken als neuen Startknoten
            }
        }

        //suche nach einem bestimmten int i im Baum
        public Node search(Node currNode, int i)
        {
            steps++; // die Schritte werden erhöht um Vergleich durchzuführen
            if (currNode.data == i) // wenn der Wert gefunden wurde, return gefundenen Node
            {
                return currNode;
            }
            else
            {
                if(i > currNode.data) // wenn der gesuchte Wert größer ist als der aktuelle Knoten, dann suche rechts weiter
                {
                    if (currNode.right == null) // wenn rechts kein Knoten mehr ist, und bis jetzt nichts gefunden wurde, dann ist der Wert nicht im Baum vorhanden -> return null
                        return null;
                    else
                        return search(currNode.right, i); // der Baum geht rechts noch weiter, daher wird search neu gestartet mit dem rechten Knoten als neuen Startknoten
                }
                else
                {
                    if (currNode.left == null)
                        return null;
                    else
                        return search(currNode.left, i); // links weitersuchen, das Ergebnis der Suche wird mittels return wieder zurückgereicht
                }
            }
        }
        public int searchInt(int i) // convenience methode für die Suche nach einem int, welche die steps auswertet
        {
            Node foundNode = search(_root, i);
            if (foundNode != null)
            {
                // gefundener Knoten (auskommentiert für Geschwindigkeitsvergleich)
                // Console.WriteLine("gefunden: " + foundNode.data);

                return steps;
            }
            else
                return 0;
        }

        public void addInt(int i) // convenience methode für das erzeugen eines neuen Nodes mit einem int
        {
            add(new Node(i), _root);
        }

        //************************************************************************************************
        //Traversierungen
        public void preOrder(Node curNode)
        {
            Console.Write(curNode.data + " "); // gibt den aktuellen Node aus

            if (curNode.left != null) // danach wird der linke Ast weiterverfolgt
                preOrder(curNode.left); // rekursiver Aufruf führt zur Ausgabe des dann aktuellen Nodes

            if (curNode.right != null) // dann erst wird der rechte Ast weitergegangen
                preOrder(curNode.right);
        }
        public void printPreOrder() // convenience methode für preOrder mit Start bei der Wurzel
        {
            preOrder(_root);
        }


        public void inOrder(Node curNode) // inOrder produziert im einem binärbaum die sortierte Ausgabe des Baums
        {
            if (curNode.left != null) // geht zuerst ganz nach links im Baum
                inOrder(curNode.left);

            Console.Write(curNode.data + " "); // gibt aktuellen Knoten aus

            if (curNode.right != null) // danach geht die Traversierung nach rechts
                inOrder(curNode.right);
        }
        public void printInOrder()
        {
            inOrder(_root);
        }

        public void postOrder(Node curNode) // geht zuerst links und rechts so weit möglich und beginnt erst "von unten nach oben" mit der Ausgabe
        {
            if (curNode.left != null)
                postOrder(curNode.left);
            
            if (curNode.right != null)
                postOrder(curNode.right);

            Console.Write(curNode.data + " ");
        }
        public void printPostOrder()
        {
            postOrder(_root);
        }

        public void min() // im Baum ist ganz links der kleinste Wert
        {
            Node curNode = _root;
            while (curNode.left != null)
                curNode = curNode.left;
            Console.WriteLine("Min: " + curNode.data);
        }

        public void max() // im Baum ist ganz rechts der größte Wert
        {
            Node curNode = _root;
            while (curNode.right != null)
                curNode = curNode.right;
            Console.WriteLine("Max: " + curNode.data);
        }


    }


    class Node
    {
        private int _data;
        public int data
        {
            get { return _data; }
            set { _data = value; }
        }


        private Node _right; // Verweis auf den Knoten rechts (Knoten mit dem größeren Wert)

        public Node right
        {
            get { return _right; }
            set { _right = value; }
        }

        private Node _left; // Verweis auf den Knoten links (Knoten mit dem kleineren Wert)

        public Node left
        {
            get { return _left; }
            set { _left = value; }
        }

        // Knoten mit Daten (in diesem Fall ein int Wert)
        public Node(int i)
        {
            _data = i;
        }

    }
}
