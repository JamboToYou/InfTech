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
        private XDocument xdoc;
        private string path;
        private int LastID;

        public XMLWorker()
        {
            path = "D:\\edu\\prog\\ИТ\\InfTech\\RGR\\RGR\\Guitars.xml";
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
                foreach (XElement xGuitar in xdoc.Root.Elements())
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
    }
}
