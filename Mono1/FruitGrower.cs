using System;
using System.Collections.Generic;
using System.Text;

namespace Mono1
{
    class FruitGrower : Person
    {
        public IFruit Fruit { get; set; }
        public string CompanyName { get; set; }

        public FruitGrower(string firstName, string lastName, IFruit fruit, string companyName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Fruit = fruit;
            this.CompanyName = companyName;
        }
        public override void SayHello() 
        {
            Console.WriteLine("Hi, my name is: " + FirstName + " and I grow " + Fruit.GetType().Name + ". ID = " + ID + "\n");
        }

        public void PrintBuissnessInfo()
        {
            Console.WriteLine("Company: " + CompanyName + " grows " + Fruit.GetType().Name);
        }

    }
}
