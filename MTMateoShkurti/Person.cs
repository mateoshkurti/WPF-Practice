using System;
using System.Collections.Generic;
using System.Text;

namespace MTMateoShkurti
{
    abstract class  Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, String name) 
        {
            Id = id;
            Name = name;
        }
    }
}
