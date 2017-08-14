using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;

namespace Super_Fight.Helpers
{
    public class EntityStorage
    {
        public List<Brands> BrandList { get; set; }
        public List<Cards> CardList { get; set; }
        public List<Matches> MatchList { get; set; }
        public List<Promotions> PromotionsList { get; set; }
        public List<Teams> TeamsList { get; set; }
        public List<TitlesMain> TitlesList { get; set; }
        public List<WrestlersMain> WrestlersList { get; set; }
    }
}
