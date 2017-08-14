using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Helpers
{
    public class IDSetterHelper
    {
        public int CurrentID(
            bool isBrands = false,
            bool isCards = false,
            bool isMatches = false,
            bool isPromotions = false,
            bool isTeams = false,
            bool isTitles = false,
            bool isWrestlers = false
            )
        {
            int currentID = 0;

            if (isBrands)
            {
                BrandHelper bHelper = new BrandHelper();
                List<BrandsEntity> allBrands = bHelper.PopulateBrandsList();

                currentID = allBrands.Count() + 1;
            }

            if (isCards)
            {
                CardHelper cHelper = new CardHelper();
                List<CardsEntity> allCards = cHelper.PopulateCardsList();

                currentID = allCards.Count() + 1;
            }

            if (isMatches)
            {
                MatchHelper mHelper = new MatchHelper();
                List<MatchesEntity> allMatches = mHelper.PopulateMatchesList();

                currentID = allMatches.Count() + 1;
            }

            if (isPromotions)
            {
                PromotionHelper pHelper = new PromotionHelper();
                List<PromotionsEntity> allPromos = pHelper.PopulatePromotionsList();

                currentID = allPromos.Count() + 1;
            }

            if (isTeams)
            {
                TeamHelper tHelper = new TeamHelper();
                List<TeamsEntity> allTeams = tHelper.PopulateTeamsList();

                currentID = allTeams.Count() + 1;
            }

            if (isTitles)
            {
                TitleHelper tiHelper = new TitleHelper();
                List<TitlesEntity> allTitles = tiHelper.PopulateTitlesList();

                currentID = allTitles.Count() + 1;
            }

            if (isWrestlers)
            {
                WrestlerHelper wHelper = new WrestlerHelper();
                List<WrestlersEntity> allWrests = wHelper.PopulateWrestlersList();

                currentID = allWrests.Count() + 1;
            }

            return currentID;
        }
    }
}
