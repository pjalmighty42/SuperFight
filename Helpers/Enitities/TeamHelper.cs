using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;

namespace Super_Fight.Helpers.Enitities
{
    public class TeamHelper
    {
        public List<TeamsEntity> PopulateTeamsList()
        {
            List<TeamsEntity> teamList = new List<TeamsEntity>();

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Teams");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Teams"));
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
                                
                                TeamsEntity team = new TeamsEntity();

                                string id = reader.ReadLine();
                                team.TeamID = Convert.ToInt32(id);

                                team.TeamName = reader.ReadLine();

                                team.OrgName = reader.ReadLine();
                                
                                team.BrandName = reader.ReadLine();

                                string wins = reader.ReadLine();
                                team.Wins = Convert.ToInt32(wins);
                                string losses = reader.ReadLine();
                                team.Losses = Convert.ToInt32(losses);
                                string draws = reader.ReadLine();
                                team.Draws = Convert.ToInt32(draws);
                                
                                team.MemberName1 = reader.ReadLine();
                                team.MemberName2 = reader.ReadLine();
                                team.MemberName3 = reader.ReadLine();
                                team.MemberName4 = reader.ReadLine();
                                
                                reader.Close();

                                teamList.Add(team);
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

            return teamList;
        }


        public void SaveTeamsList(TeamsEntity team)
        {
            FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "\\Saves\\Main\\Teams\\" + team.TeamID + ".dat", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(team.TeamID);

            writer.WriteLine(team.TeamName);
            writer.WriteLine(team.OrgName);
            
            writer.WriteLine(team.BrandName);

            writer.WriteLine(team.Wins);
            writer.WriteLine(team.Losses);
            writer.WriteLine(team.Draws);
            
            writer.WriteLine(team.MemberName1);
            writer.WriteLine(team.MemberName2);
            writer.WriteLine(team.MemberName3);
            writer.WriteLine(team.MemberName4);

            writer.Close();
            stream.Close();
        }
    }
}
