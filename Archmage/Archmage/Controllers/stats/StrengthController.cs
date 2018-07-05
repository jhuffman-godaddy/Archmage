using Archmage.Models.AbilityScores;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Archmage.Controllers.Stats
{
  [Route("stats/str")]
  public class StrengthController : Controller
  {
    [Route("")]
    public JObject GetStrengthTable()
    {
      return JObject.Parse(Properties.Resources.Strength);
    }

    [Route("{abilityScore}")]
    public StrengthModel GetStrengthModifiers(int abilityScore)
    {
      return GetStrengthModifiers(abilityScore, null);
    }

    [Route("{abilityScore}/{percentile}")]
    public StrengthModel GetStrengthModifiers(int abilityScore, int? percentile)
    {
      return new StrengthModel(abilityScore, percentile);
    }
  }
}