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


    }
}
