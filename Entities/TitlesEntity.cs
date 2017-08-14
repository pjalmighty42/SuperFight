using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Fight.Entities
{
    public class TitlesEntity
    {
        public int TitleID { get; set; }
        public string Name { get; set; }
        public string OwnerOrgName { get; set; } //Conn: Title to Org
        
        public string BrandName { get; set; } //Conn: Title to Brand

        public string WeightClass { get; set; }
        public string Specialization { get; set; } //Singles, Tag, 6-Man, 8-Man, Battle Royal
        public string GenereType { get; set; } //Normal, Hardcore, SWA, Gruesome

        //Conn: Title to Wresters
        public string HolderName1 { get; set; } 
        public string HolderName2 { get; set; }
        public string HolderName3 { get; set; }
        public string HolderName4 { get; set; }
    }
}
