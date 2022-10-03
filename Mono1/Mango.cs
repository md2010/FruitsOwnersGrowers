using System;
using System.Collections.Generic;
using System.Text;

namespace Mono1
{
    class Mango : IFruit
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public string Taste { get; set; }
       
        public Mango (string color, string taste)
        {
            this.Color = color;
            this.Taste = taste;
        }
        
        public string GetVitamins()
        {
            return "A, C and K";
        }

        public override string ToString()
        {
            return "I'm a mango and I'm " + Color + " ,I taste " + Taste + " and I have " + this.GetVitamins() + " vitamins. ID = " + ID + "\n";
        }
    }
}
