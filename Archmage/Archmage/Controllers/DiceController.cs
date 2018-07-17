using Archmage.Models;
using Microsoft.AspNetCore.Mvc;

namespace Archmage.Controllers
{
  [Route("dice")]
  [ApiController]
  public class DiceController : Controller
  {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="die"></param>
    /// <param name="sides"></param>
    /// <param name="rollMod"></param>
    /// <param name="totalMod"></param>
    /// <returns></returns>
    [HttpGet("{die}/{sides}")]
    public DiceRollModel Roll(int die, int sides, int rollMod = 0, int totalMod = 0)
    {
      return new DiceRollModel(die, sides, rollMod, totalMod);
    }

  }
}