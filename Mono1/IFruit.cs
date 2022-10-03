using System;
using System.Collections.Generic;
using System.Text;

namespace Mono1
{
    interface IFruit
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public string Taste { get; set; }

        public string GetVitamins();

        public string ToString();
    
    }
}
