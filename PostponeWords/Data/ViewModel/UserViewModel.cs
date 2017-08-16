using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostponeWords.Data.ViewModel
{
    public class UserViewModel
    {
    public string Email;
    public string Password;
    public UserViewModel(string Email, string Password)
    {
      this.Email = Email;
      this.Password = Password;
    }
}
}
