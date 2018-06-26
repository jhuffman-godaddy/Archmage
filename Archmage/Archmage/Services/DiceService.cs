using System;

namespace Archmage.Services
{
    public static class DiceService
    {
      public static int[] Roll(int die, int sides, int rollModifier)
      {
        var rolls = new int[die];
        var random = new Random();

        for (var i = 0; i < die; i++)
        {
          rolls[i] = random.Next(1, sides + 1) + rollModifier;
        }

        return rolls;
      }
    }
}
