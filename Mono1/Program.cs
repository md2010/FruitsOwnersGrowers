using System;
using System.Linq;
using System.Collections.Generic;

namespace Mono1
{
    class Program
    {
        static FruitStorage fruitStorage = new FruitStorage();
        static PersonStorage personStorage = new PersonStorage();

        static string menu = "For funcionality press number:\n" +
                "Meet owners - 1\nAdd owner - 2\nGet owners's fruits by the ID of owner - 3\nAdd fruit to owner - 4 \n" +                
                "Meet fruits - 5\nAdd fruit - 6\n" +             
                "Meet growers - 7\nBuisness Information - 8\nAdd grower - 9\n";
        static void Main(string[] args)
        {
            //setup
            Apple greenApple = new Apple("green", "sour");
            FruitGrower appleGrower = new FruitGrower("John", "Bond", greenApple, "Apple Agriculture d.o.o.");

            Mango mango = new Mango("red", "sweet");
            FruitGrower mangoGrower = new FruitGrower("Mark", "Regez", mango, "Egzotic Agriculture d.o.o.");

            Owner owner1 = new Owner("Tim", "Timothy", "Road St. 5");
            owner1.AddFruitToOwner(greenApple);

            personStorage.Add(appleGrower);
            personStorage.Add(mangoGrower);
            personStorage.Add(owner1);

            fruitStorage.Add(greenApple);
            fruitStorage.Add(mango);

            //interaction
            Run();
        }

        static void Run()
        {
            Console.WriteLine(menu);
            string input = Console.ReadLine();           

            switch (input)
            {
                case "1":
                    personStorage.OwnersToString();
                    Run();
                    break;
                case "2":
                    CreateOwner();
                    Run();
                    break;
                case "3":
                    GetOwnersFruits();
                    Run();
                    break;
                case "4":
                    AddFruitToOwner();
                    Run();
                    break;
                case "5":
                    fruitStorage.PrintAll();
                    Run();
                    break;
                case "6":
                    CreateFruit();
                    Run();
                    break;
                case "7":
                    personStorage.GrowersToString();
                    Run();
                    break;
                case "8":
                    personStorage.GetGrowersBuissnessInformation();
                    Run();
                    break;
                case "9":
                    CreateGrower();
                    Run();
                    break;
                default:
                    break;
            }
        }


        //each case in method
        static void Error()
        {
            Console.WriteLine("Error occured :( \n ");
            Run();
        }

        static void CreateOwner()
        {
            Console.WriteLine("Enter first name, last name and address for new owner, every property in new line!");
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string address = Console.ReadLine();
            Owner owner = new Owner(firstName, lastName, address);
            personStorage.Add(owner);
            Console.WriteLine("Owner added successfully!");          
        }

        static void GetOwnersFruits()
        {
            Console.WriteLine("Enter ID of owner of whom you want to see a list of fruits.");
            string line = Console.ReadLine();
            int ID = int.Parse(line);
            Owner owner = personStorage.getOwnerByID(ID);
            Console.WriteLine("Owners fruits:\n");
            owner.PrintAllOwnersFruits();
        }

       static void AddFruitToOwner()
        {
            personStorage.OwnersToString();
            Console.WriteLine("Above is list of owners, choose to whom you want to add fruit by typing owner's ID.");
            string line = Console.ReadLine();
            int ID = int.Parse(line);
            Owner owner = personStorage.getOwnerByID(ID);
            if(owner == null)
            {
                Error();
            }

            fruitStorage.PrintAll();
            Console.WriteLine("Above is list of fruits, choose which one you want to add to owner by typing fruit's ID." +
                "If you want to add more fruits at once type Y.\n");
            line = "";
            line = Console.ReadLine();
            if (line == "Y")
            {
                AddFruitsToOwner(owner);
            }
            else
            {
                ID = int.Parse(line);
                IFruit fruit = fruitStorage.getFruitByID(ID);
                if (fruit == null)
                {
                    Error();
                }

                owner.AddFruitToOwner(fruit);
                Console.WriteLine("Fruit added to owner successfully!");
            }
        }

        static void AddFruitsToOwner(Owner owner)
        {
            Console.WriteLine("Type in fruit IDs seperated by comma (example: 1, 2, 3).\n");
            string line = Console.ReadLine();
            List<int> ids = line.Split(',').Select(int.Parse).ToList();
            foreach(int id in ids)
            {
                IFruit fruit = fruitStorage.getFruitByID(id);
                if (fruit == null)
                {
                    Error();
                }

                owner.AddFruitToOwner(fruit);
                Console.WriteLine("Fruit with ID = " + id + " has been added to owner successfully!");
            }
        }

        static void CreateGrower()
        {
            fruitStorage.PrintAll();
            Console.WriteLine("Enter first name, last name, fruit ID (see list above) and name of company for new grower, every property in new line!");
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string line = Console.ReadLine();
            string company = Console.ReadLine();

            int ID = int.Parse(line);
            IFruit fruit = fruitStorage.getFruitByID(ID);
            if (fruit == null)
            {
                Error();
            }

            FruitGrower grower = new FruitGrower(firstName, lastName, fruit, company);
            personStorage.Add(grower);
            Console.WriteLine("Fruit Grower added successfully!");
        }

        static void CreateFruit()
        {     
            Console.WriteLine("Below is list of available fruits. You can create for example apples with different color" +
                " and taste.\n");
            fruitStorage.PrintAvailableFruits();
            Console.WriteLine("Below is list of all fruits that already exist.\n");
            fruitStorage.PrintAll();
            List<string> input = GetInputForNewFruit();
            Console.WriteLine("Now type in which fruit you want to create.\n");
            string line = Console.ReadLine().ToLower();
            
            if (line == "apple")
            {
                Apple apple = new Apple(input[0], input[1]);
                fruitStorage.Add(apple);
            }
            else if(line == "mango")
            {
                Mango mango = new Mango(input[0], input[1]);
                fruitStorage.Add(mango);
            } 
            else if (line == "orange")
            {
                Orange orange = new Orange(input[0], input[1]);
                fruitStorage.Add(orange);
            }
        }

        static List<string> GetInputForNewFruit()
        {
            Console.WriteLine("Type in color and taste, each in new line.\n");
            string color = Console.ReadLine();
            string taste = Console.ReadLine();
            List<string> input = new List<string> { color, taste };
            return input;
        }

    }
}
