using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PostponeWords.Data
{
  public class WordsApiWorker:IWordsApiWorker
  {
    public async Task<string> GetDegenitionsAsync(string word)
    {
      return await GetDataAsync(word, "definitions");
    }
    public async Task<string> GetExamplesAsync(string word)
    {
      return await GetDataAsync(word, "examples");
    }

    private static async Task<string> GetDataAsync(string word, string action)
    {
      WebResponse response = null;
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://wordsapiv1.p.mashape.com/words/{word}/{action}");
      request.Headers["X-Mashape-Key"] = "y0gl4NyjTlmshwNGIm7O4HcHzdlCp1mBlpKjsndD8Yz653sWjK";
      request.Headers["Accept"] = "application/json";
      request.Credentials = CredentialCache.DefaultCredentials;

      try
      {
        response = await request.GetResponseAsync();
      }
      catch(WebException ex) { return ""; }
      
      if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
      { 
      Stream dataStream = response.GetResponseStream();
      StreamReader reader = new StreamReader(dataStream);
      string responseFromServer = reader.ReadToEnd();

      return responseFromServer;
      }
      return "";
    }
  }
}
