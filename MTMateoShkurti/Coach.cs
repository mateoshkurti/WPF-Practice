using System;
using System.Collections.Generic;
using System.Text;

namespace MTMateoShkurti
{
    class Coach :Person
    {
        public int NumberOfTeamsCoached { get; set; }
        public int PlayersTrained { get; set; }
        public double WinPercentage { get; set; }
        public  int YearsOfExperience { get; set; }

        public Coach(int id, string name, int teamsCoached, int playerstrained, double winPercentage, int YoE) : base(id, name) 
        {
            NumberOfTeamsCoached = teamsCoached;
            PlayersTrained = playerstrained;
            WinPercentage = winPercentage;
            YearsOfExperience = YoE;
        }
    }
}
