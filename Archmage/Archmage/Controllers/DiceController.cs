using Archmage.Models;
using Archmage.Services;
using Microsoft.AspNetCore.Mvc;

namespace Archmage.Controllers
{
  [Route("dice")]
  public class DiceController : Controller
  {
    [Route("{die}/{sides}")]
    public DiceRollModel Roll(int die, int sides, int rollMod = 0, int totalMod = 0)
    {
      return new DiceRollModel(die, sides, rollMod, totalMod);
    }
  }
}