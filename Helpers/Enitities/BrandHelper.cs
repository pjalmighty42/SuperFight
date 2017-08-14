using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;

namespace Super_Fight.Helpers.Enitities
{
    public class BrandHelper
    {
        public List<BrandsEntity> PopulateBrandsList()
        {
            List<BrandsEntity> brandList = new List<BrandsEntity>();

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Brands");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Brands"));
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
                                
                                BrandsEntity brand = new BrandsEntity();

                                string id = reader.ReadLine();
                                brand.BrandID = Convert.ToInt32(id);

                                brand.Name = reader.ReadLine();
                                brand.ConnOrgName = reader.ReadLine();

                                brandList.Add(brand);
                                
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

            return brandList;
        }


        public void SaveBrandsList(BrandsEntity brand)
        {
            FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "\\Saves\\Main\\Brands\\" + brand.BrandID + ".dat", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(brand.BrandID);

            writer.WriteLine(brand.Name);
            writer.WriteLine(brand.ConnOrgName);

            writer.Close();
            stream.Close();
        }
    }
}
