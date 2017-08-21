using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostponeWords.Data
{
  public interface IWordsApiWorker
  {
    Task<string> GetDegenitionsAsync(string word);
    Task<string> GetExamplesAsync(string word);
  }
}
