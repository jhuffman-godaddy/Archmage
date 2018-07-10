using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Archmage.Controllers.Stats
{
  [ApiController]
  public class StatsController : Controller
  {

    [HttpGet]
    [Route("stats")]
    public IList<object> GetStats()
    {
      var stats = new List<object>
          {
            new DexterityController().GetDexterityTable(),
            new StrengthController().GetStrengthTable()
          };

      return stats;
    }
  }
}
