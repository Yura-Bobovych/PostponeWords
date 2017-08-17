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

  }
  

}
namespace PostponeWords.AppSettingsParams
{
  public class JwtIssuerOptions
  {
    public string Issuer { get; set; }
    public string Audience { get; set; }
  }
}
