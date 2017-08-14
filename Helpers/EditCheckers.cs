using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Fight.Helpers
{
    public class EditCheckers
    {
        public bool NoPromotionsSettings()
        {
            bool bisPromotion = false;

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\" + "\\" + "Main" + "\\" + "Promotions" );

            if (Directory.Exists(dir))
            {
                FileInfo[] files = (new DirectoryInfo(dir).GetFiles("*.dat"));

                if (files.Length == 0)
                {
                    bisPromotion = false;
                }
                else
                {
                    bisPromotion = true;
                }
            }

            return bisPromotion;
        }

        public bool NoWrestlersSettings()
        {
            bool bisWrestler = false;

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\" + "\\" + "Main" + "\\" + "Wrestlers");

            if (Directory.Exists(dir))
            {
                FileInfo[] files = (new DirectoryInfo(dir).GetFiles("*.dat"));

                if (files.Length == 0)
                {
                    bisWrestler = false;
                }
                else
                {
                    bisWrestler = true;
                }
            }

            return bisWrestler;
        }

        public bool NoTeamsSettings()
        {
            bool bHasTeams = false;

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\" + "\\" + "Main" + "\\" + "Teams");

            if (Directory.Exists(dir))
            {
                FileInfo[] files = (new DirectoryInfo(dir).GetFiles("*.dat"));

                if (files.Length == 0)
                {
                    bHasTeams = false;
                }
                else
                {
                    bHasTeams = true;
                }
            }

            return bHasTeams;
        }

        public bool NoTitlesSettings()
        {
            bool bHasTitles = false;

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\" + "\\" + "Main" + "\\" + "Titles");

            if (Directory.Exists(dir))
            {
                FileInfo[] files = (new DirectoryInfo(dir).GetFiles("*.dat"));

                if (files.Length == 0)
                {
                    bHasTitles = false;
                }
                else
                {
                    bHasTitles = true;
                }
            }

            return bHasTitles;
        }

        public bool NoMatchesSettings()
        {
            bool bHasTitles = false;

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\" + "\\" + "Main" + "\\" + "Titles");

            if (Directory.Exists(dir))
            {
                FileInfo[] files = (new DirectoryInfo(dir).GetFiles("*.dat"));

                if (files.Length == 0)
                {
                    bHasTitles = false;
                }
                else
                {
                    bHasTitles = true;
                }
            }

            return bHasTitles;
        }

        public bool NoCardsSettings()
        {
            bool bHasCards = false;

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\" + "\\" + "Main" + "\\" + "Cards");

            if (Directory.Exists(dir))
            {
                FileInfo[] files = (new DirectoryInfo(dir).GetFiles("*.dat"));

                if (files.Length == 0)
                {
                    bHasCards = false;
                }
                else
                {
                    bHasCards = true;
                }
            }

            return bHasCards;
        }
    }
}
