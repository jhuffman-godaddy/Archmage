using System.Diagnostics;
using Archmage.Models.Stats;
using Archmage.Services;

namespace Archmage.Models.AbilityScores
{
    public class DexterityModel : AbilityScore
    {
      public DexterityModel(int abilityScore)
      {
        Value = abilityScore;
        if (AbilityScoreService.TryGetDexterityModifiers(abilityScore, 
          out var reactionAdjustment, out var missleAttackAdjustment, out var defensiveAdjustment))
        {
          ReactionAdjustment = reactionAdjustment;
          MissleAttackAdjustment = missleAttackAdjustment;
          DefensiveAdjustment = defensiveAdjustment;
        }
        else
        {
          Debug.WriteLine($"Failed to retrieve modifiers for Dexterity:{abilityScore}");
        }
      }
      public int? ReactionAdjustment { get; }
      public int? MissleAttackAdjustment { get; }
      public int? DefensiveAdjustment { get; }
    }
}
