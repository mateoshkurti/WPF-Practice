using System;
using System.Collections.Generic;
using System.Text;

namespace MTMateoShkurti
{
    class Player: Person
    {
        public int MatchesPlayed { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int GoalsScored { get; set; }

        public Player(int id, string name, int matchesPlayed, int won, int lost, int goalsScored):base (id,name) 
        {
            MatchesPlayed = matchesPlayed;
            Won = won;
            Lost = lost;
            GoalsScored = goalsScored;
        }
    }
}
