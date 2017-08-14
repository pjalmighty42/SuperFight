using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Fight.Entities
{
    public class TeamsEntity
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }

        public string OrgName { get; set; } //Conn: Team to Org
        
        public string BrandName { get; set; } //Conn: Team to Brand

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        
        //Conn: Team to Wrestlers
        public string MemberName1 { get; set; }
        public string MemberName2 { get; set; }
        public string MemberName3 { get; set; }
        public string MemberName4 { get; set; }
    }
}
