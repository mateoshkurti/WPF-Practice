using System;
using System.Collections.Generic;
using System.Text;

namespace MTMateoShkurti
{
    class Manager: Person
    {
        public int PlayersRecruted{ get; set; }
        public double AvailableBudget  { get; set; }

        public String Strength { get; set; }

        public Manager(int id, String name, int playersRecruted, double availableBudget, string strength) : base(id, name)
        {
            PlayersRecruted = playersRecruted;
            AvailableBudget = availableBudget;
            Strength = strength;
        }
    }
}
