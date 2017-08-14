using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Fight.Entities
{
    public class CardsEntity
    {
        public int CardID { get; set; }
        public string CardName { get; set; }  //Conn: Card to Match
        public string SubTitle { get; set; }
        public string Location { get; set; }
        public string BrandName { get; set; }

        public string ConnOrgName { get; set; } //Conn: Card to Org
        
        public int NumOfMatches { get; set; }

        public int FinalCardRating { get; set; }
        
    }
}
