using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostponeWords.Data.ViewModel;
using PostponeWords.Data;
using PostponeWords.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostponeWords.Controllers
{
  [Route("api/[controller]/[action]")]
  public class AccountController : Controller
  {
    private readonly IUserWorker userWorker;

    public AccountController(IUserWorker userWorker)
    {
      this.userWorker = userWorker;
    }
    //Register
    [HttpPost]
    public void Register([FromBody]UserViewModel user)
    {
     Console.WriteLine(userWorker.CreateUser(user.Email,user.Password));  
     
    
    }
    public void Login([FromBody]UserViewModel user)
    {
      Console.WriteLine(userWorker.VerifyUser(user.Email, user.Password));
      
    }

  }
}
