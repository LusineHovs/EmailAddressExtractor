# EmailAddressExtractor

This application downloads given webpage's html code and saves it in html file(**HtmlDownloader class**) 
```C#
class HtmlDownloader:IDisposable
{
  private StreamWriter sr;
  private WebClient wc;

  public HtmlDownloader(string path)
  {
      wc = new WebClient();
      sr = new StreamWriter(path);
  }

  public void Save(string url)
  {
      if (url == null)
      {
          throw new ArgumentNullException(nameof(url));
      }
      var uri = new Uri(url);
      var html = wc.DownloadString(uri);
      sr.Write(html);
  }
  ```
and from this html code recognizes *email addresses* and writes thess in text file(**MailExtractor class**).
``` c#
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
  ```
 
 **Below you can see how does it work**
