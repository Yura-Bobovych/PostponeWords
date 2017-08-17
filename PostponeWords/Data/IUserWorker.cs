using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostponeWords.Data.Models;

namespace PostponeWords.Data
{
    public interface IUserWorker 
    {
    User CreateUser(string email, string password);
    User FindByEmail(string email);
    bool UserExist(string email);
    bool CheckPassword(User user,string password);
  }
}
