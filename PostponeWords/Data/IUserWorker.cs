using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostponeWords.Data.Models;

namespace PostponeWords.Data
{
    public interface IUserWorker 
    {
    bool CreateUser(string email, string password);
    bool UserExist(string email);
    bool VerifyUser(string email, string password);
  }
}
