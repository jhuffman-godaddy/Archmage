using Archmage.Models.AbilityScores;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Archmage.Controllers.Stats
{

  [Route("stats/dex")]
  [ApiController]
  public class DexterityController : Controller
  {

    [HttpGet]
    [Route("")]
    public JObject GetDexterityTable()
    {
      return JObject.Parse(Properties.Resources.Dexterity);
    }

    [HttpGet]
    [Route("{abilityScore}")]
    public DexterityModel GetDexterityModifiers(int abilityScore)
    {
      return new DexterityModel(abilityScore);
    }
  }
}
