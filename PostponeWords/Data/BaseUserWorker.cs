using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostponeWords.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace PostponeWords.Data
{
  public class BaseUserWorker : IUserWorker
  {
    #region properties
    private readonly PostponeWordsContext context;
    private const string staticHeshParam = "285c593422dd471c37b46b4c658686131b3aa5a8"; // pass hesh= sha1(sha1(pass+salt+staticParam))
    public BaseUserWorker(PostponeWordsContext context)
    {
      this.context = context;
    }
    #endregion
    #region public 
    public bool CreateUser(string email, string password)
    {
      if (UserExist(email))
      {
        User user = new User();
        user.Email = email;
        user.Salt = GetSalt(password);
        user.Hesh = GetPasswordHesh(password, user.Salt);
        context.User.Add(user);
        context.SaveChanges();
        return true;
      }
      return false;
    }
    public bool UserExist(string email)
    {

      if (context.User.Where(u => u.Email == email) == null)
      { return false; }
      return true;
    }
    public bool VerifyUser(string email, string password)
    {
      User user = context.User.Where(u => u.Email == email).First();
      if (user != null)
      {
        if (user.Hesh == GetPasswordHesh(password, user.Salt)) { return true; }
      }
      return false;
    }
    #endregion
    #region private
    private string GetSalt(string password)
    {
      string salt = "";
      int seed = 0;
      foreach (char ch in password)
      {
        seed += (int)ch * DateTime.Now.Millisecond + DateTime.Now.Second; //make random seed for each user
      }
      Random r = new Random(seed);
      for (int i = 0; i < 10; i++)
      {
        int x = r.Next(0, 61) + 48; //61 different characters + 48 (ascii offset to first character);
        x = x > 57 ? x + 7 : x; // bad charcters [58,64] ascii 
        x = x > 90 ? x + 6 : x;// bad charcters [91,96] ascii 
        salt += (char)x;
      }
      return salt;
    }
    private string GetPasswordHesh(string passsword, string salt)
    {
      string result = "";
      using (SHA1 sha1 = SHA1.Create())
      {
        var hash = sha1.ComputeHash(sha1.ComputeHash(Encoding.UTF8.GetBytes(passsword + salt + staticHeshParam)));
        var sb = new StringBuilder(hash.Length * 2);

        foreach (byte b in hash)
        {
          sb.Append(b.ToString("X2"));
        }

        result = sb.ToString();
        return result;
      }
    }
    #endregion
  }
}
