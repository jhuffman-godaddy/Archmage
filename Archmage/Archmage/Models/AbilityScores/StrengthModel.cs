using System.Diagnostics;
using Archmage.Models.Stats;
using Archmage.Services;

namespace Archmage.Models.AbilityScores
{
  public class StrengthModel : AbilityScore
  {
    public int? Percentile { get; }
    public int? ToHitAdjustment { get; }
    public int? DamageAdjustment { get; }
    public int? WeightAllowance { get; }
    public int? MaxPress { get; }
    public float? OpenDoors { get; }
    public float? OpenLockedBarredMagicDoors { get; }
    public float? BendBarsLiftGates { get; }

    public StrengthModel(int abilityScore, int? percentile = null)
    {
      Value = abilityScore;
      Percentile = percentile;
      if (AbilityScoreService.TryGetStrengthModifiers(abilityScore, percentile,
        out var toHitAdjustment, out var damageAdjustment, out var weightAllowance,
        out var maxPress, out var openDoors, out var openLockedBarredMagicDoors,
        out var bendBarsLiftGates))
      {
        ToHitAdjustment = toHitAdjustment;
        DamageAdjustment = damageAdjustment;
        WeightAllowance = weightAllowance;
        MaxPress = maxPress;
        OpenDoors = openDoors;
        OpenLockedBarredMagicDoors = openLockedBarredMagicDoors;
        BendBarsLiftGates = bendBarsLiftGates;
      }
      else
      {
        Debug.WriteLine($"Failed to retrieve modifiers for Strength:{abilityScore}, Percentile:{Percentile}");
      }
    }
  }
}
