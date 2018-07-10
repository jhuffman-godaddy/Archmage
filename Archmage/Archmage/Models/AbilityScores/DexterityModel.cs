using System.Diagnostics;
using Archmage.Models.Stats;
using Archmage.Services;
using Newtonsoft.Json;

namespace Archmage.Models.AbilityScores
{
  public class DexterityModel : AbilityScore
  {
    [JsonProperty]
    public int? ReactionAdjustment { get; }
    public int? MissleAttackAdjustment { get; }
    public int? DefensiveAdjustment { get; }
    public int? Surprise { get; }

    public DexterityModel(int abilityScore)
    {
      Value = abilityScore;
      if (AbilityScoreService.TryGetDexterityModifiers(abilityScore,
        out var reactionAdjustment, out var missleAttackAdjustment, out var defensiveAdjustment, out var surprise))
      {
        ReactionAdjustment = reactionAdjustment;
        MissleAttackAdjustment = missleAttackAdjustment;
        DefensiveAdjustment = defensiveAdjustment;
        Surprise = surprise;
      }
      else
      {
        Debug.WriteLine($"Failed to retrieve modifiers for Dexterity:{abilityScore}");
      }
    }
  }
}
