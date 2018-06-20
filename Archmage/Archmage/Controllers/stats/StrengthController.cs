using Archmage.Models.AbilityScores;
using Microsoft.AspNetCore.Mvc;

namespace Archmage.Controllers
{
  [Route("stats/str")]
  public class StrengthController : Controller
  {
    [Route("{abilityScore}")]
    public StrengthModel GetStrengthModifiers(int abilityScore, int? percentile = null)
    {
      return new StrengthModel(abilityScore, percentile);
    }
  }
}