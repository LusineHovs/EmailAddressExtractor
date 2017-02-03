using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace EmailAddressExtracor
{
    class MailExtractor
    {
        public static void ExtractEmails(string inFilePath, string outFilePath)
        {
            string data = File.ReadAllText(inFilePath); //read File 
                                                        //instantiate with this pattern 
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
            //find items that matches with our pattern
            MatchCollection emailMatches = emailRegex.Matches(data);

            //StringBuilder sb = new StringBuilder();
            string s = "";
            foreach (Match emailMatch in emailMatches)
            {
                //sb.AppendLine(emailMatch.Value);
                s += emailMatch.Value + "\r\n";
            }
            //store to file
            File.WriteAllText(outFilePath, s.ToString());
        }
    }
}
