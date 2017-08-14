using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;

namespace Super_Fight.Helpers.Enitities
{
    public class TitleHelper
    {
        public List<TitlesEntity> PopulateTitlesList()
        {
            List<TitlesEntity> titleList = new List<TitlesEntity>();

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Titles");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Titles"));
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
                                
                                TitlesEntity title = new TitlesEntity();

                                string id = reader.ReadLine();
                                title.TitleID = Convert.ToInt32(id);

                                title.Name = reader.ReadLine();
                                title.OwnerOrgName = reader.ReadLine();
                                
                                title.BrandName = reader.ReadLine();

                                title.WeightClass = reader.ReadLine();
                                title.Specialization = reader.ReadLine();
                                title.GenereType = reader.ReadLine();

                                title.HolderName1 = reader.ReadLine();
                                title.HolderName2 = reader.ReadLine();
                                title.HolderName3 = reader.ReadLine();
                                title.HolderName4 = reader.ReadLine();

                                titleList.Add(title);

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

            return titleList;
        }


        public void SaveTitlesList(TitlesEntity title)
        {
            FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "\\Saves\\Main\\Titles\\" + title.TitleID + ".dat", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(title.TitleID);

            writer.WriteLine(title.Name);
            writer.WriteLine(title.OwnerOrgName);
            
            writer.WriteLine(title.BrandName);

            writer.WriteLine(title.WeightClass);
            writer.WriteLine(title.Specialization);
            writer.WriteLine(title.GenereType);

            writer.WriteLine(title.HolderName1);
            writer.WriteLine(title.HolderName2);
            writer.WriteLine(title.HolderName3);
            writer.WriteLine(title.HolderName4);

            writer.Close();
            stream.Close();
        }
    }
}
