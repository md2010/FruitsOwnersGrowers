using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Mono1
{
    class FruitStorage
    {
        HashSet<IFruit> Fruits { get; set; } //no duplicates in HashSet (no need for 2 green sour apples)    
        List<string> AvailableFruits { get; set; }
        public FruitStorage()
        {
            this.Fruits = new HashSet<IFruit>();
            this.AvailableFruits = new List<string>{"Apple", "Mango", "Orange"}; 
        }

        public void PrintAvailableFruits()
        {
            foreach(string s in AvailableFruits)
            {
                Console.WriteLine(s);
            }
        }
       
        public void Add(IFruit fruit)
        {           
            if (!Fruits.Add(fruit))
            {             
                Console.WriteLine("That kind of fruit already exists!");
            }
            else
            {
                fruit.ID = Fruits.Count + 1;
                Console.WriteLine("Fruit added succesfully!");
            }
        }      

        public void PrintAll()
        {
            foreach(IFruit fruit in Fruits)
            {
                Console.WriteLine(fruit.ToString());
            }
        }

        public IFruit getFruitByID(int ID)
        {
            List<IFruit> list = new List<IFruit>();
            list = Fruits.ToList<IFruit>(); // hashSet doesn't have Find or Where but List does
            IFruit fruit = list.Find(i => i.ID == ID);
            if (fruit == null)
            {
                Console.WriteLine("Fruit doesn't exist!");
                return null;
            }
            else
            {
                return fruit;
            }
        }
       
    }
}
