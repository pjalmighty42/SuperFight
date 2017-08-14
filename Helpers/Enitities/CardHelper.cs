using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;

namespace Super_Fight.Helpers.Enitities
{
    public class CardHelper
    {
        public List<CardsEntity> PopulateCardsList()
        {
            List<CardsEntity> cardList = new List<CardsEntity>();

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Cards");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Cards"));
            }
            else
            {
                FileInfo[] files = (new DirectoryInfo(dir).GetFiles("*.dat"));

                if (files.Length > 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        try
                        {
                            FileInfo info = files[i];

                            using (StreamReader reader = new StreamReader(info.FullName))
                            {
                                
                                CardsEntity card = new CardsEntity();

                                string id = reader.ReadLine();
                                card.CardID = Convert.ToInt32(id);

                                card.CardName = reader.ReadLine();
                                card.SubTitle = reader.ReadLine();
                                card.Location = reader.ReadLine();
                                card.BrandName = reader.ReadLine();

                                card.ConnOrgName = reader.ReadLine();
                                
                                string matchesNum = reader.ReadLine();
                                card.NumOfMatches = Convert.ToInt32(matchesNum);

                                string finalRating = reader.ReadLine();
                                card.FinalCardRating = Convert.ToInt32(finalRating);

                                cardList.Add(card);

                                reader.Close();
                                //stream.Close();
                            }
                        }
                        catch (Exception e)
                        {
                            dir = string.Concat(Directory.GetCurrentDirectory(), "\\Logs");

                            if (!Directory.Exists(dir))
                            {
                                Directory.CreateDirectory(string.Concat(Directory.GetCurrentDirectory(), "\\Logs"));
                            }

                            string log = "Log - " + DateTime.Today.Ticks.ToString();

                            FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "\\Logs\\" + log + ".dat", FileMode.Create, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(stream);

                            string err = e.ToString();
                            writer.WriteLine(err + "\n");

                            writer.Close();
                            stream.Close();
                        }
                    }
                }
            }

            return cardList;
        }


        public void SaveCardsList(CardsEntity card)
        {
            FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "\\Saves\\Main\\Cards\\" + card.CardID + ".dat", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(card.CardID);

            writer.WriteLine(card.CardName);
            writer.WriteLine(card.SubTitle);
            writer.WriteLine(card.Location);
            writer.WriteLine(card.BrandName);

            writer.WriteLine(card.ConnOrgName);
            
            writer.WriteLine(card.NumOfMatches);

            writer.WriteLine(card.FinalCardRating);

            writer.Close();
            stream.Close();
        }
    }
}
