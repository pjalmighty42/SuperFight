using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;

namespace Super_Fight.Helpers.Enitities
{
    public class PromotionHelper
    {
        public List<PromotionsEntity> PopulatePromotionsList()
        {
            List<PromotionsEntity> promotionList = new List<PromotionsEntity>();

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Promotions");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Promotions"));
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
                               
                                PromotionsEntity promotion = new PromotionsEntity();

                                string id = reader.ReadLine();
                                promotion.OrgID = Convert.ToInt32(id);

                                promotion.Name = reader.ReadLine();
                                promotion.Initals = reader.ReadLine();
                                promotion.Location = reader.ReadLine();
                                
                                promotionList.Add(promotion);

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

            return promotionList;
        }


        public void SavePromotionsList(PromotionsEntity promotion)
        {
            FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "\\Saves\\Main\\Promotions\\" + promotion.OrgID + ".dat", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(promotion.OrgID);

            writer.WriteLine(promotion.Name);
            writer.WriteLine(promotion.Initals);
            writer.WriteLine(promotion.Location);

            writer.Close();
            stream.Close();
        }
    }
}
