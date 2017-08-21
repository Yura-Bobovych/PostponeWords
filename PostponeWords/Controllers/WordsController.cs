using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Net;
using System.IO;
using PostponeWords.Data;

namespace PostponeWords.Controllers
{
  [Authorize(Policy ="BaseUser")]
  [Route("api/[controller]/[action]")]
  public class WordsController : Controller
  {    
    private readonly IWordsApiWorker WordsApi;
    public WordsController(IWordsApiWorker worker)
    {
      WordsApi = worker;
    }


    [HttpGet]
    public async Task<string> Meaning(string word)
    {       
      return await WordsApi.GetDegenitionsAsync(word);
    }
  }
}
