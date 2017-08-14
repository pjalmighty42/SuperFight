using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;

namespace Super_Fight.Helpers.Enitities
{
    public class WrestlerHelper
    {
        public List<WrestlersEntity> PopulateWrestlersList()
        {
            List<WrestlersEntity> wrestList = new List<WrestlersEntity>();

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Wrestlers");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Wrestlers"));
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
                                
                                WrestlersEntity wrest = new WrestlersEntity();

                                string id = reader.ReadLine();
                                wrest.WrestlerID = Convert.ToInt32(id);

                                wrest.Name = reader.ReadLine();
                                wrest.WeightClass = reader.ReadLine();
                                wrest.CurrentCompanyName = reader.ReadLine();

                                string wins = reader.ReadLine();
                                wrest.Wins = Convert.ToInt32(wins);
                                string losses = reader.ReadLine();
                                wrest.Losses = Convert.ToInt32(losses);
                                string draws = reader.ReadLine();
                                wrest.Draws = Convert.ToInt32(draws);
                                
                                wrest.BrandName = reader.ReadLine();
                                
                                wrest.TeamName = reader.ReadLine();

                                wrestList.Add(wrest);

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

            return wrestList;
        }


        public void SaveWrestlersList(WrestlersEntity wrest)
        {
            FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "\\Saves\\Main\\Wrestlers\\" + wrest.WrestlerID + ".dat", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(wrest.WrestlerID);

            writer.WriteLine(wrest.Name);
            writer.WriteLine(wrest.WeightClass);
            writer.WriteLine(wrest.CurrentCompanyName);

            writer.WriteLine(wrest.Wins);
            writer.WriteLine(wrest.Losses);
            writer.WriteLine(wrest.Draws);
            
            writer.WriteLine(wrest.BrandName);

            writer.WriteLine(wrest.TeamName);
            
            writer.Close();
            stream.Close();
        }
    }
}
