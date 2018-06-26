using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Archmage.Controllers.Stats
{
    public class StatsController : Controller
    { 

        [Route("stats")]
        public IList<object> GetStats()
        {
          var stats = new List<object> {new DexterityController().GetDexterityTable()};


          return stats;
        }
    }
}
