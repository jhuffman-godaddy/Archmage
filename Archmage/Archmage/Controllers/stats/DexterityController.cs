using Archmage.Models.AbilityScores;
using Microsoft.AspNetCore.Mvc;

namespace Archmage.Controllers.AbilityScores
{
  [Route("stats/dex")]
  [ApiController]
  public class DexterityController : Controller
  {
    [Route("{abilityScore}")]
    public DexterityModel GetDexterityModifiers(int abilityScore)
    {
      return new DexterityModel(abilityScore);
    }
  }
}
