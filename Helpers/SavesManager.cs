using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Helpers
{
    public class SavesManager
    {
        public void SaveGame(
           List<Brands> brands,
           List<Cards> cards,
           List<Matches> matches,
           List<Promotions> promotions,
           List<Teams> teams,
           List<TitlesMain> titles,
           List<WrestlersMain> wrestlers
        )
        {
            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(string.Concat(Directory.GetCurrentDirectory(), "\\Saves"));
            }
            else
            {
                string main = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\" +  "\\" + "Main");

                if (!Directory.Exists(main))
                {
                    Directory.CreateDirectory(string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\" + "\\" + "Main"));
                }
                else
                {
                    BrandHelper bHelper = new BrandHelper();
                    CardHelper cHelper = new CardHelper();
                    MatchHelper mHelper = new MatchHelper();
                    PromotionHelper pHelper = new PromotionHelper();
                    TeamHelper tHelper = new TeamHelper();
                    TitleHelper tlHelper = new TitleHelper();
                    WrestlerHelper wHelper = new WrestlerHelper();

                    foreach (Brands b in brands)
                    {
                        bHelper.SaveBrandsList(b);
                    }

                    foreach (Cards c in cards)
                    {
                        cHelper.SaveCardsList(c);
                    }

                    foreach (Matches m in matches)
                    {
                        mHelper.SaveMatchesList(m);
                    }

                    foreach (Promotions p in promotions)
                    {
                        pHelper.SavePromotionsList(p);
                    }

                    foreach (Teams t in teams)
                    {
                        tHelper.SaveTeamsList(t);
                    }

                    foreach (TitlesMain tl in titles)
                    {
                        tlHelper.SaveTitlesList(tl);
                    }

                    foreach (WrestlersMain w in wrestlers)
                    {
                        wHelper.SaveWrestlersList(w);
                    }
                }
            }
        }

        public void LoadGame(
           out List<Brands> brands,
           out List<Cards> cards,
           out List<Matches> matches,
           out List<Promotions> promotions,
           out List<Teams> teams,
           out List<TitlesMain> titles,
           out List<WrestlersMain> wrestlers
        )
        {
            BrandHelper bHelper = new BrandHelper();
            CardHelper cHelper = new CardHelper();
            MatchHelper mHelper = new MatchHelper();
            PromotionHelper pHelper = new PromotionHelper();
            TeamHelper tHelper = new TeamHelper();
            TitleHelper tlHelper = new TitleHelper();
            WrestlerHelper wHelper = new WrestlerHelper();

            brands = bHelper.PopulateBrandsList();
            cards = cHelper.PopulateCardsList();
            matches = mHelper.PopulateMatchesList();
            promotions = pHelper.PopulatePromotionsList();
            teams = tHelper.PopulateTeamsList();
            titles = tlHelper.PopulateTitlesList();
            wrestlers = wHelper.PopulateWrestlersList();
        }
    }
}
