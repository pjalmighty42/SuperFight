using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Fight.Entities
{
    public class WrestlersEntity
    {
        public int WrestlerID { get; set; }
        public string Name { get; set; }
        public string WeightClass { get; set; }
        public string CurrentCompanyName { get; set; } //Conn: Wrestlers to Org
        
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        
        public string BrandName { get; set; } //Conn: Wrestlers to Brand
        
        public string TeamName { get; set; } //Conn: Wrestlers to Team
    }
}
