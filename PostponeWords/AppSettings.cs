using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostponeWords.AppSettingsParams;
namespace PostponeWords
{
  public class AppSettings
  {
    public string StaticHesh { get; set; }
    public JwtIssuerOptions JwtIssuerOptions { get; set; }
    public string SigningKey { get; set; }
    public JwtClaimIdentifiers JwtClaimIdentifiers { get; set; }
    public JwtClaims JwtClaims { get; set; }
    public AuthorizationPolicy AuthorizationPolicy { get; set; }
  }
  

}
namespace PostponeWords.AppSettingsParams
{
  public class JwtIssuerOptions
  {
    public string Issuer { get; set; }
    public string Audience { get; set; }
  }
  public class JwtClaimIdentifiers
  {
    public string Rol { get; set; }
    public string Id { get; set; }
  }
  public class JwtClaims
  {
    public string BaseUser { get; set; }
  }
  public class AuthorizationPolicy
  {
    public string BaseUser { get; set; }
  }

}
