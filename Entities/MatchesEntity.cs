using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Fight.Entities
{
    public class MatchesEntity
    {
        public int MatchID { get; set; }

        public int CardMatchNumber { get; set; }
        public string MatchTitle { get; set; }

        public string AttachedCardName { get; set; }  //Conn: Match to Card

        public string MatchType { get; set; } // 1 - Singles, 2 - Tag, 3 - 6-Man, 4 - 8-Man, 5 - Battle Royal

        public string MatchRules { get; set; }
        
        public int NumOfRounds { get; set; } //If Rounds = true
        public int MinsPerRound { get; set; } //If Rounds = true

        public int MatchMins { get; set; }
        public int NumOfFalls { get; set; }
        
        public string Title { get; set; } //If Titles = true

        //Participants
        public string Participant1 { get; set; }
        public string Participant2 { get; set; }
        public string Participant3 { get; set; }
        public string Participant4 { get; set; }
        public string Participant5 { get; set; }
        public string Participant6 { get; set; }
        public string Participant7 { get; set; }
        public string Participant8 { get; set; }

        //Finalize Stats
        public string RedSideResult { get; set; }
        public string BlueSideResult { get; set; }

        public string MatchWinners { get; set; }

        public int FinalNumOfRounds { get; set; } //If Rounds = true
        public int FinalFallCount { get; set; } //If Rounds = false

        public int FinalMatchMins { get; set; }
        public int FinalMatchSecs { get; set; }

        public int MatchRating { get; set; }
    }
}
