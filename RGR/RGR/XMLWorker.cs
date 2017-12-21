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
    class XMLWorker
    {
        public XDocument xdoc;
        public string path;
        private int LastID;

        public XMLWorker()
        {
            path = "Guitars.xml";
            xdoc = XDocument.Load(path);

            XmlReaderSettings setting = new XmlReaderSettings();

            setting.DtdProcessing = DtdProcessing.Parse;
            setting.ValidationType = ValidationType.DTD;
            setting.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            XmlReader reader = XmlReader.Create(path, setting);

            while (reader.Read());

            LastID = -1;

            foreach (XElement xType in xdoc.Root.Elements())
            {
                foreach (XElement xGuitar in xType.Elements())
                {
                    xGuitar.Attribute("ID").SetValue((++LastID).ToString());
                }
            }
        }

        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Validation Error: {0}", e.Message);
        }

        public LinkedList<Guitar> GetAllGuitars()
        {
            LinkedList<Guitar> list = new LinkedList<Guitar>();

            foreach (XElement xType in xdoc.Root.Elements())
            {
                foreach (XElement xGuitar in xType.Elements())
                {
                    list.AddLast(new Guitar(int.Parse(xGuitar.Attribute("ID").Value),
                                            xGuitar.Parent.Name.ToString(),
                                            xGuitar.Parent.Attribute("Type").Value,
                                            xGuitar.Element("MadeBy").Value,
                                            xGuitar.Element("Model").Value,
                                            xGuitar.Element("DeckWood").Value,
                                            xGuitar.Element("FingerboardWood").Value,
                                            xGuitar.Element("Weight").Value,
                                            xGuitar.Element("Length").Value,
                                            xGuitar.Element("Price").Value));
                }
            }
            

            return list;
        }

        public void AddGuitar(Guitar guitar)
        {
            bool f = false;
            foreach (XElement xType in xdoc.Root.Elements(guitar.Variation1))
            {
                if (xType.Attribute("Type").Value == guitar.Type1)
                {
                    xType.Add(new XElement("Guitar", new XAttribute("ID", ++LastID),
                                    new XElement("MadeBy", guitar.MadeBy1),
                                    new XElement("Model", guitar.Model1),
                                    new XElement("DeckWood", guitar.DeckWood1),
                                    new XElement("FingerboardWood", guitar.FingerboardWood1),
                                    new XElement("Weight", guitar.Weight1),
                                    new XElement("Length", guitar.Price1),
                                    new XElement("Price", guitar.Price1)));
                    f = true;
                    break;
                }
            }

            if (!f)
            {
                xdoc.Root.Add(new XElement(guitar.Variation1, new XAttribute("Type", guitar.Type1),
                    new XElement("Guitar", new XAttribute("ID", ++LastID),
                                    new XElement("MadeBy", guitar.MadeBy1),
                                    new XElement("Model", guitar.Model1),
                                    new XElement("DeckWood", guitar.DeckWood1),
                                    new XElement("FingerboardWood", guitar.FingerboardWood1),
                                    new XElement("Weight", guitar.Weight1),
                                    new XElement("Length", guitar.Price1),
                                    new XElement("Price", guitar.Price1))));
            }
        }

        public bool DeleteByID(int ID)
        {
            bool result = false;

            foreach (XElement xType in xdoc.Root.Elements())
            {
                foreach (XElement xGuitar in xType.Elements())
                {
                    if (xGuitar.Attribute("ID").Value == ID.ToString())
                    {
                        xGuitar.Remove();
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        public void UpdateGuitar(int ID, string TagName, string NewData)
        {
            bool flag = true;
            foreach (XElement xType in xdoc.Root.Elements())
            {
                foreach (XElement xGuitar in xType.Elements())
                {
                    if (xGuitar.Attribute("ID").Value == ID.ToString())
                    {
                        xGuitar.Element(TagName).SetValue(NewData);
                        flag = false;
                    }
                }
            }
            if (flag) View.NoTagFoundMessage();
        }
    }
}
