using System;
using System.Collections.Generic;
using System.Text;

namespace Mono1
{
    class Owner : Person
    {
        public List<IFruit> Fruits { get; set; } //List --> can have more than just one apple  
        private string Address { get; set; }
        
        public Owner(string firstName, string lastName, string address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Fruits = new List<IFruit>();
            this.Address = address;
        }

        public void AddFruitToOwner(IFruit fruit) 
        {
            Fruits.Add(fruit);
        }
        public void AddFruitToOwner(List<IFruit> list) //overloading
        {
            foreach(IFruit fruit in list)
            {
                Fruits.Add(fruit);
            }
        }
        public void PrintAllOwnersFruits()
        {
            if(Fruits.Count == 0)
            {
                Console.WriteLine("This owner doesn't own any fruits!");
                return;
            }
            foreach (IFruit fruit in Fruits)
            {
                Console.WriteLine(fruit.ToString());
            }
        }

        public override void SayHello()
        {
            Console.WriteLine("Hi, my name is " + FirstName + " and I am fruit owner. ID = " + ID + "\n");
        }       

    }
}
