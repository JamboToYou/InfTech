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
            XmlSchemaInference infer = new XmlSchemaInference();
            XmlSchemaSet schemaSet =
              infer.InferSchema(new XmlTextReader("Puzzles.xml"));

            XmlWriter w = XmlWriter.Create("Puzzles.xsd");
            foreach (XmlSchema schema in schemaSet.Schemas())
            {
                schema.Write(w);
            }
            w.Close();
            XDocument xdoc = XDocument.Load("Puzzles.xsd");
            Console.WriteLine(xdoc);
            Console.ReadKey();

            XDocument xDocument = XDocument.Load("Puzzles.xml");

            XmlSchemaSet Schema = new XmlSchemaSet();
            schemaSet.Add(null, "Puzzles.xsd");
            try
            {
                xDocument.Validate(schemaSet, null);
                Console.WriteLine("Проверка достоверности документа завершена успешно");
            }
            catch (XmlSchemaValidationException ex)
            {
                Console.WriteLine("Произошло исключение:   {0}", ex.Message);
                Console.WriteLine("Документ не прошел проверку достоверности.");
            }
            Console.ReadKey();
        }
    }
}
