using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAddressExtracor
{
    class Program
    {
        static void Main(string[] args)
        {
            //HtmlDownloader class execution
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = Path.Combine(desktop, "HtmlExtractor.html");
            var hd = new HtmlDownloader(path);
            hd.Save("http://antares.am/contacts/");
            hd.Dispose();


            // Mail extraction process
            string inFilePath = path;
            string outFilePath = "C:/Users/L.Hovsepyan/Desktop/MailList.txt";
            MailExtractor.ExtractEmails(inFilePath, outFilePath);
        }
    }
}
