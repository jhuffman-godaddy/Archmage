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
    public JObject GetDexterityTable()
    {
      return JObject.Parse(Properties.Resources.Dexterity);
    }

    [HttpGet("{abilityScore}")]
    public DexterityModel GetDexterityModifiers(int abilityScore)
    {
      return new DexterityModel(abilityScore);
    }
  }
}
