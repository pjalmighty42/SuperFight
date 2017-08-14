using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Super_Fight.Entities;

namespace Super_Fight.Helpers.Enitities
{
    public class MatchHelper
    {
        public List<MatchesEntity> PopulateMatchesList()
        {
            List<MatchesEntity> matchList = new List<MatchesEntity>();

            string dir = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Matches");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Matches"));
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
                                MatchesEntity match = new MatchesEntity();

                                string id = reader.ReadLine();
                                match.MatchID = Convert.ToInt32(id);

                                string matchNum = reader.ReadLine();
                                match.CardMatchNumber = Convert.ToInt32(matchNum);
                                match.MatchTitle = reader.ReadLine();

                                match.AttachedCardName = reader.ReadLine();
                                    
                                match.MatchType = reader.ReadLine();

                                match.MatchRules = reader.ReadLine();
                                    
                                string roundNum = reader.ReadLine();
                                match.NumOfRounds = Convert.ToInt32(roundNum);
                                string roundTime = reader.ReadLine();
                                match.MinsPerRound = Convert.ToInt32(roundTime);

                                string matchTime = reader.ReadLine();
                                match.MatchMins = Convert.ToInt32(matchTime);
                                string fallsCount = reader.ReadLine();
                                match.NumOfFalls = Convert.ToInt32(fallsCount);
                                    
                                match.Title = reader.ReadLine();

                                match.Participant1 = reader.ReadLine();
                                match.Participant2 = reader.ReadLine();
                                match.Participant3 = reader.ReadLine();
                                match.Participant4 = reader.ReadLine();
                                match.Participant5 = reader.ReadLine();
                                match.Participant6 = reader.ReadLine();
                                match.Participant7 = reader.ReadLine();
                                match.Participant8 = reader.ReadLine();

                                match.RedSideResult = reader.ReadLine();
                                match.BlueSideResult = reader.ReadLine();

                                match.MatchWinners = reader.ReadLine();

                                string finalRnds = reader.ReadLine();
                                match.FinalNumOfRounds = Convert.ToInt32(finalRnds);
                                string finalFall = reader.ReadLine();
                                match.FinalFallCount = Convert.ToInt32(finalFall);
                                
                                string finalMins = reader.ReadLine();
                                match.FinalMatchMins = Convert.ToInt32(finalMins);
                                string finalSecs = reader.ReadLine();
                                match.FinalMatchSecs = Convert.ToInt32(finalSecs);

                                string rating = reader.ReadLine();
                                match.MatchRating = Convert.ToInt32(rating);

                                matchList.Add(match);

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

            return matchList;
        }


        public void SaveMatchesList(MatchesEntity match)
        {
            FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "\\Saves\\Main\\Matches\\" + match.MatchID + ".dat", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(match.MatchID);

            writer.WriteLine(match.CardMatchNumber);
            writer.WriteLine(match.MatchTitle);

            writer.WriteLine(match.AttachedCardName);

            writer.WriteLine(match.MatchType);

            writer.WriteLine(match.MatchRules);
            
            writer.WriteLine(match.NumOfRounds);
            writer.WriteLine(match.MinsPerRound);

            writer.WriteLine(match.MatchMins);
            writer.WriteLine(match.NumOfFalls);
            
            writer.WriteLine(match.Title);

            writer.WriteLine(match.Participant1);
            writer.WriteLine(match.Participant2);
            writer.WriteLine(match.Participant3);
            writer.WriteLine(match.Participant4);
            writer.WriteLine(match.Participant5);
            writer.WriteLine(match.Participant6);
            writer.WriteLine(match.Participant7);
            writer.WriteLine(match.Participant8);

            writer.WriteLine(match.RedSideResult);
            writer.WriteLine(match.BlueSideResult);

            writer.WriteLine(match.MatchWinners);

            writer.WriteLine(match.FinalNumOfRounds);
            writer.WriteLine(match.FinalFallCount);

            writer.WriteLine(match.FinalMatchMins);
            writer.WriteLine(match.FinalMatchSecs);

            writer.WriteLine(match.MatchRating);

            writer.Close();
            stream.Close();
        }
    }
}
