using System;
using System.Collections.Generic;
using System.Text;

namespace Mono1
{
    class Orange : IFruit
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public string Taste { get; set; }

        public Orange(string color, string taste)
        {
            this.Color = color;
            this.Taste = taste;
        }
        public string GetVitamins()
        {
            return "C and B1.";
        }

        public override string ToString()
        {
            return "I'm an orange and I'm " + Color + " ,I taste " + Taste + " and I have " + this.GetVitamins() + " vitamins. ID = " + ID + "\n";
        }
    }
}
