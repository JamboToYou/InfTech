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
            XmlReaderSettings setting = new XmlReaderSettings();

            setting.DtdProcessing = DtdProcessing.Parse;
            setting.ValidationType = ValidationType.DTD;
            setting.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            XmlReader reader = XmlReader.Create("D:\\edu\\prog\\ИТ\\InfTech\\RGR\\RGR\\Guitars.xml", setting);

            while (reader.Read()) ;

            Console.ReadKey();
        }

        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Validation Error: {0}", e.Message);
        }
    }
}
