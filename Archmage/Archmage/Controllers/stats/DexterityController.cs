using Archmage.Models.AbilityScores;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Archmage.Controllers.Stats
{

  [Route("stats/dex")]
  [ApiController]
  public class DexterityController : Controller
  {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public JObject GetDexterityTable()
    {
      return JObject.Parse(Properties.Resources.Dexterity);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="abilityScore"></param>
    /// <returns></returns>
    [HttpGet("{abilityScore}")]
    public DexterityModel GetDexterityModifiers(int abilityScore)
    {
      return new DexterityModel(abilityScore);
    }
  }
}
