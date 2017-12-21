using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    class View
    {
        private XMLWorker xmlWorker;

        public View(XMLWorker xw)
        {
            if (xw != null) xmlWorker = xw;
            else throw new ArgumentException();
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("Choose the option : " + Environment.NewLine +
                "1. Show all guitars" + Environment.NewLine +
                "2. Add new guitar" + Environment.NewLine + 
                "3. Update guitar" + Environment.NewLine + 
                "4. Delete guitar" + Environment.NewLine +
                "5. Exit");
        }

        public void ShowGuitars()
        {
            LinkedList<Guitar> list = xmlWorker.GetAllGuitars();

            foreach (Guitar guitar in list)
            {
                Console.WriteLine(guitar);
                Console.WriteLine("__--||=================||--__");
            }
        }

        public void AddGuitar()
        {
            string MadeBy = "";
            string Model = "";
            string DeckWood = "";
            string FingerboardWood = "";
            string Weight = "";
            string Length = "";
            string Price = "";
            string Variation = "";
            string Type = "";

            GetValue("type of guitar (acoustic, electric, etc)", out Variation);
            GetValue("type of deck (western, classic, straticaster, etc)", out Type);
            GetValue("manufacturer",out MadeBy);
            GetValue("model of this guitar",out Model);
            GetValue("wood of deck", out DeckWood);
            GetValue("wood of grif", out FingerboardWood);
            GetDoubleData("weight", out Weight);
            GetDoubleData("length", out Length);
            GetDoubleData("price", out Price);

            xmlWorker.AddGuitar(new Guitar(Variation, Type, MadeBy, Model, DeckWood, FingerboardWood, Weight, Length, Price));
        }

        private void GetValue(string substring, out string data)
        {
            Console.Write($"Enter the {substring} : ");
            data = Console.ReadLine();
        }

        public void GetDoubleData(string substring, out string data)
        {
            do
            {
                GetValue(substring, out data);
            } while (!double.TryParse(data, out double g) || g < 0);
        }

        public void UpdateGuitar()
        {
            Console.WriteLine("Choose the guitar to update or press Enter to cancel : ");
            ShowGuitars();

            string iD = Console.ReadLine();
            if (iD == null) return;
            if(!int.TryParse(iD, out int ID) || ID < 0)
            {
                Console.WriteLine("Bad data for ID");
                return;
            }
            Dictionary<string, string> tagName = new Dictionary<string, string>
            {
                {"1", "MadeBy"},
                {"2", "Model"},
                {"3", "DeckWood"},
                {"4", "FingerboardWood"},
                {"5", "Weight"},
                {"6", "Length"},
                {"7", "Price"}
            };

            Console.WriteLine("Choose the tag to update :" + Environment.NewLine + 
                "1. Made by" + Environment.NewLine +
                "2. Model" + Environment.NewLine + 
                "3. Deck wood" + Environment.NewLine +
                "4. Fingerboard wood" + Environment.NewLine +
                "5. Weight" + Environment.NewLine +
                "6. Length" + Environment.NewLine +
                "7. Price");

            string TagName = Console.ReadLine();

            switch (TagName)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                    Console.WriteLine("Enter the new value :");
                    string data = Console.ReadLine();
                    xmlWorker.UpdateGuitar(ID, tagName[TagName], data);
                    break;
                default:
                    break;
            }
        }
        public static void NoTagFoundMessage()
        {
            Console.WriteLine("No such tag found");
        }

        public void DeleteGuitar()
        {
            Console.WriteLine("Choose the guitar to delete : ");
            ShowGuitars();
            string iD = Console.ReadLine();
            if (!int.TryParse(iD, out int ID) || ID < 0)
            {
                Console.WriteLine("Bad data for ID");
                return;
            }

            if (!xmlWorker.DeleteByID(ID)) Console.WriteLine("Wrong ID entry");
        }
    }
}
