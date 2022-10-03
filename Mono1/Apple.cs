using System;
using System.Collections.Generic;
using System.Text;

namespace Mono1
{
    class Apple : IFruit
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public string Taste { get; set; }

        public Apple(string color, string taste)
        {
            this.Color = color;
            this.Taste = taste;           
        }
       
        public string GetVitamins()
        {
            return "C";
        }

        public override string ToString()
        {
            return "I'm an apple and I'm " + Color + ", I taste " + Taste + " and I have "+ this.GetVitamins() + " vitamins. ID = " + ID + "\n";
        }
      
    }
}
