using System.Collections.Generic;
using Archmage.Services;

namespace Archmage.Models
{
    public class DiceRollModel
    {
      public DiceRollModel(int die, int sides, int rollModifier, int totalModifier)
      {
        Die = die;
        Sides = sides;
        RollModifier = rollModifier;
        TotalModifier = totalModifier;
        Rolls = DiceService.Roll(die, sides, rollModifier);
        Total = Accumulate(Rolls) + TotalModifier;
        Description = ToString();
      }
      public int Die { get; }
      public int Sides { get; }
      public int[] Rolls { get; }
      public int RollModifier { get; }
      public int TotalModifier { get; }
      public int Total { get; }
      public string Description { get; }
      public sealed override string ToString()
      {
        return $"{Die}d{Sides}({ModifierService.ModifierSymbol(RollModifier)}{RollModifier}/die){ModifierService.ModifierSymbol(TotalModifier)+TotalModifier}";
      }

      private static int Accumulate(IEnumerable<int> rolls)
      {
        var sum = 0;

        foreach (var roll in rolls)
        {
          sum += roll;
        }

        return sum;
      }
    }
}
