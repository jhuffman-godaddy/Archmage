using Archmage.Models.AbilityScores;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Archmage.Controllers.Stats
{
  [ApiController]
  [Route("stats/str")]
  public class StrengthController : Controller
  {
    [HttpGet]
    [Route("")]
    public JObject GetStrengthTable()
    {
      return JObject.Parse(Properties.Resources.Strength);
    }

    [HttpGet]
    [Route("{abilityScore}")]
    public StrengthModel GetStrengthModifiers(int abilityScore)
    {
      return GetStrengthModifiers(abilityScore, null);
    }

    [HttpGet]
    [Route("{abilityScore}/{percentile}")]
    public StrengthModel GetStrengthModifiers(int abilityScore, int? percentile)
    {
      return new StrengthModel(abilityScore, percentile);
    }
  }
}