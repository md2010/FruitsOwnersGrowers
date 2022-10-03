using System;
using System.Collections.Generic;
using System.Text;

namespace Mono1
{
    abstract class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

       private void ChangeLastName(string newLastName)
        {
            LastName = newLastName;
        }

        public abstract void SayHello();      
    }
}
