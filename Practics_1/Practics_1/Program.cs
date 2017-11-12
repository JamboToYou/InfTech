using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics_1
{
    class Program
    {
        public static bool isEnd = false;
        public static string xmlPath;
        public static XmlDocument xDoc = openXml();


        static void Main(string[] args)
        {
            XmlElement xRoot = xDoc.DocumentElement;

            while (!isEnd)
            {
                mainMenu();
                input(xRoot);

                xDoc.Save(xmlPath);

                awaiting();
            }
        }
        public static void awaiting()
        {
            Console.WriteLine(Environment.NewLine + "Нажмите любую кнопку для возврата в меню . . .");
            Console.ReadKey();
        }

        public static void input(XmlElement xRoot)
        {
            string buf = Console.ReadLine();
            switch (buf)
            {
                case "1":
                    Console.Clear();
                    displayXml(xRoot);
                    break;
                case "2":
                    addNewBook(xRoot);
                    break;
                case "3":
                    changeBook(xRoot);
                    break;
                case "4":
                    removeBook(xRoot);
                    break;
                case "5":
                default:
                    isEnd = true;
                    break;
            }
        }

        public static void mainMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "Выберите действие:" + Environment.NewLine
                + "1. Вывести список книг" + Environment.NewLine
                + "2. Добавить новую книгу" + Environment.NewLine
                + "3. Изменить информацию о книге" + Environment.NewLine
                + "4. Удалить книгу" + Environment.NewLine
                + "5. Выйти"
                );
        }

        public static void displayXml(XmlElement xRoot)
        {
            int i = 1;

            Console.WriteLine(xRoot.Name + Environment.NewLine);

            foreach (XmlElement xNode in xRoot)
            {
                Console.WriteLine("{0} {1}:", i++, xNode.Name);
                foreach (XmlElement xElem in xNode)
                {
                    Console.WriteLine("{0}:{1}", xElem.Name, xElem.InnerText);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }

        public static XmlDocument openXml()
        {
            XmlDocument xDoc = new XmlDocument();

            Console.WriteLine("Введите путь к xml-файлу: ");
            xmlPath = Console.ReadLine();

            xDoc.Load(xmlPath);

            if (xDoc == null)
            {
                throw new Exception("Wrong path");
            }
            else return xDoc;
        }


        public static void addNewBook(XmlElement xRoot)
        {
            Console.Clear();

            XmlElement sonOfGod = (XmlElement) xRoot.FirstChild;

            XmlElement newBook = xDoc.CreateElement("BOOK");
            
            foreach (XmlElement xElem in sonOfGod)
            {
                XmlElement elem = xDoc.CreateElement(xElem.Name);
                Console.Write("Введите значение для {0}: ", elem.Name);
                XmlText text = xDoc.CreateTextNode(Console.ReadLine());
                Console.WriteLine();

                elem.AppendChild(text);
                newBook.AppendChild(elem);
            }

            xRoot.AppendChild(newBook);
            Console.WriteLine("Новая книга добавлена");
        }

        public static void changeBook(XmlElement xRoot)
        {
            XmlElement xElem = prepareField(xRoot);

            Console.Clear();
            foreach(XmlElement elem in xElem)
            {
                Console.Write("Введите новое значение для {0}: ", elem.Name);
                elem.InnerText = Console.ReadLine();
                Console.WriteLine();
            }
            Console.WriteLine("Книга именена");
        }

        public static void removeBook(XmlElement xRoot)
        {
            XmlElement elemToRemove = prepareField(xRoot);
            xRoot.RemoveChild(elemToRemove);
            Console.WriteLine("Книга удалена");
        }

        public static XmlElement prepareField(XmlElement xRoot)
        {
            Console.Clear();
            Console.WriteLine("Выберите книгу:" + Environment.NewLine);

            displayXml(xRoot);

            int i;
            string buf = Console.ReadLine();
            int.TryParse(buf, out i);

            XmlElement xElem = (XmlElement)xRoot.ChildNodes[i - 1];

            return xElem;
        }
    }
}
