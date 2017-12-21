using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace RGR
{
    class Program
    {
        public static void Main()
        {
            XMLWorker xw = new XMLWorker();
            View view = new View(xw);
            bool end = false;
            string option = "";

            while (!end)
            {
                Console.Clear();
                view.ShowMainMenu();

                option = Console.ReadLine();

                Console.Clear();
                switch (option)
                {
                    case "1":
                        view.ShowGuitars();
                        break;
                    case "2":
                        view.AddGuitar();
                        break;
                    case "3":
                        view.UpdateGuitar();
                        break;
                    case "4":
                        view.DeleteGuitar();
                        break;
                    case "5":
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Wrong option");
                        break;
                }

                Console.WriteLine("Press Enter to continue. . .");
                Console.ReadKey();
                //xw.xdoc.Save(xw.path);
            }
        }
    }
}
