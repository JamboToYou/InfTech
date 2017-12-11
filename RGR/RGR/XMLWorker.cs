using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RGR
{
    class XMLWorker
    {
        private XDocument xdoc;
        private string path;

        public XMLWorker()
        {
            xdoc = XDocument.Load("Model.xml");
        }


    }
}
