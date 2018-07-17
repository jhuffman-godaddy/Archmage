using Archmage.Models.AbilityScores;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Archmage.Controllers.Stats
{
  [ApiController]
  [Route("stats/str")]
  public class StrengthController : Controller
  {

    /// <summary>
    /// Get the strength modifiers for all ability scores.
    /// </summary>
    /// <returns>JSON blob of Strength Tabel.</returns>
    [HttpGet("")]
    public JObject GetStrengthTable()
    {
      return JObject.Parse(Properties.Resources.Strength);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="abilityScore"></param>
    /// <returns></returns>
    [HttpGet("{abilityScore}")]
    public StrengthModel GetStrengthModifiers(int abilityScore)
    {
      return GetStrengthModifiers(abilityScore, null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="abilityScore"></param>
    /// <param name="percentile"></param>
    /// <returns></returns>
    [HttpGet("{abilityScore}/{percentile}")]
    public StrengthModel GetStrengthModifiers(int abilityScore, int? percentile)
    {
      return new StrengthModel(abilityScore, percentile);
    }
  }
}