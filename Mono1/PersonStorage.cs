using System;
using System.Collections.Generic;
using System.Text;

namespace Mono1
{
    class PersonStorage 
    {
        List<Owner> Owners { get; set; } //no duplicates in HashSet
        List<FruitGrower> Growers { get; set; } //no duplicates in HashSet (no need for 2 green sour apples)

        public PersonStorage()
        {
            this.Owners = new List<Owner>();
            this.Growers = new List<FruitGrower>();
        }

        public void Add(FruitGrower grower) 
        {
            grower.ID = Growers.Count + 1;
            Growers.Add(grower);         
        }

        public void Add(Owner owner) //overloading
        {
            owner.ID = Owners.Count + 1;
            Owners.Add(owner);          
        }

        public void OwnersToString()
        {
            foreach(Owner owner in Owners)
            {
                owner.SayHello();
            }
        }

        public void GrowersToString()
        {
            foreach (FruitGrower grower in Growers)
            {
                grower.SayHello();
            }
        }

        public void GetGrowersBuissnessInformation()
        {
            foreach (FruitGrower grower in Growers)
            {
                grower.PrintBuissnessInfo();
            }
        }

        public Owner getOwnerByID(int ID)
        {
            Owner owner = Owners.Find(i => i.ID == ID);
            if(owner == null)
            {
                Console.WriteLine("Owner doesn't exist!");
                return null;
            } 
            else
            {
                return owner;
            }          
        }
    }
}
