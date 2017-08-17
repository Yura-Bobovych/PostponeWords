using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostponeWords.Data.ViewModel;
using PostponeWords.Data;
using PostponeWords.Data.Models;
using System.Security.Claims;
using PostponeWords.Data.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostponeWords.Controllers
{
  [Route("api/[controller]/[action]")]
  public class AccountController : Controller
  {
    private readonly IUserWorker userWorker;
    private readonly IJwtFactory jwtFactory;
    private readonly JwtIssuerOptions jwtOptions;
    public AccountController(IUserWorker userWorker, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
    {
      this.jwtFactory = jwtFactory;
      this.jwtOptions = jwtOptions.Value;
      this.userWorker = userWorker;
    }
    //Register
    [HttpPost]
    public void Register([FromBody]UserViewModel user)
    {
     Console.WriteLine(userWorker.CreateUser(user.Email,user.Password));  
     
    
    }
    public async Task<IActionResult> Login([FromBody]UserViewModel user)
    {

      var identity = GetClaimsIdentity(user.Email, user.Password);
      if(identity !=null)
      { 
      var response = new
      {
        id = identity.Claims.Single(c => c.Type == "id").Value,
        auth_token = await jwtFactory.GenerateEncodedToken(user.Email, identity),
        expires_in = (int)jwtOptions.ValidFor.TotalSeconds
      };
      var json = JsonConvert.SerializeObject(response);
      return new OkObjectResult(json);
      }
      return null;

    }
    private ClaimsIdentity GetClaimsIdentity(string userName, string password)
    {
      if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
      {
        var userToVerify = userWorker.FindByEmail(userName);
        if (userToVerify != null)
        {
          if(userWorker.CheckPassword(userToVerify,password))
          {
            return jwtFactory.GenerateClaimsIdentity(userName,userToVerify.Id); 
          }
        }
      }
      return null;
    }
  }
}
