using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Helpers
{
    public class StoreEntitiesHelper
    {
        public string BrandNameValue { get; set; }
        public string SpecilizationValue { get; set; }
        public int CurrMatchID { get; set; }

        public List<BrandsEntity> BrandsList { get; set; }
        public List<CardsEntity> CardsList { get; set; }
        public List<MatchesEntity> MatchesList { get; set; }
        public List<PromotionsEntity> PromotionsList { get; set; }
        public List<TeamsEntity> TeamsList { get; set; }
        public List<TitlesEntity> TitlesList { get; set; }
        public List<WrestlersEntity> WrestlersList { get; set; }

        public StoreEntitiesHelper()
        {
            BrandsList = new List<BrandsEntity>();
            CardsList = new List<CardsEntity>();
            MatchesList = new List<MatchesEntity>();
            PromotionsList = new List<PromotionsEntity>();
            TeamsList = new List<TeamsEntity>();
            TitlesList = new List<TitlesEntity>();
            WrestlersList = new List<WrestlersEntity>();
        }
    }
}
