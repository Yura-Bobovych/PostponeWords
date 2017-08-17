using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PostponeWords.Data;

namespace PostponeWords.Data
{
    public interface IJwtFactory
    {
    Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
    ClaimsIdentity GenerateClaimsIdentity(string userName, int id);
  }
}
