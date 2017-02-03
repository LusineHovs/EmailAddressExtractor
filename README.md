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
and from this html code recognizes *email addresses* and writes thess in text file(**MailExtractor**).
