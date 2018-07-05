using System;
using Archmage.Models.AbilityScores;
using Archmage.Models.AbilityScores.Modifiers;
using Newtonsoft.Json.Linq;

namespace Archmage.Services
{
  public static class AbilityScoreService
  {
    private const string Modifiers = "Modifiers";

    public static bool TryGetDexterityModifiers(int abilityScore,
      out int reactionAdjustment, out int missileAttackAdjustment, out int defensiveAdjustment, out int surprise)
    {
      reactionAdjustment = int.MinValue;
      missileAttackAdjustment = int.MinValue;
      defensiveAdjustment = int.MinValue;
      surprise = int.MinValue;

      if (!IsValidAbilityScore(abilityScore))
      {
        return false;
      }

      var modifiers = GetModifiers(Properties.Resources.Dexterity, abilityScore);

      reactionAdjustment = GetModifier(modifiers, Dexterity.ReactionAdjustment);
      missileAttackAdjustment = GetModifier(modifiers, Dexterity.MissileAttackAdjustment);
      defensiveAdjustment = GetModifier(modifiers, Dexterity.DefensiveAdjustment);
      surprise = GetModifier(modifiers, Dexterity.Surprise);
      
      return true;
    }

    public static bool TryGetStrengthModifiers(int abilityScore, 
      int? percentile, out int toHitAdjustment, out int damageAdjustment, out int weightAllowance,
      out int maxPress, out float openDoors, out float openLockedBarredOrMagicDoors, out float bendBarsLiftGates)
    {
      toHitAdjustment = int.MinValue;
      damageAdjustment = int.MinValue;
      weightAllowance = int.MinValue;
      maxPress = int.MinValue;
      openDoors = float.MinValue;
      openLockedBarredOrMagicDoors = float.MinValue;
      bendBarsLiftGates = float.MinValue;

      if (!IsValidAbilityScore(abilityScore, percentile))
      {
        return false;
      }

      var modifiers = GetModifiers(Properties.Resources.Strength, abilityScore, percentile);

      toHitAdjustment = GetModifier(modifiers, Strength.ToHitAdjustment);
      damageAdjustment = GetModifier(modifiers, Strength.DamageAdjustment);
      weightAllowance = GetModifier(modifiers, Strength.WeightAllowance);
      maxPress = GetModifier(modifiers, Strength.MaxPress);
      openDoors = GetModifier(modifiers, Strength.OpenDoors);
      openLockedBarredOrMagicDoors = GetModifier(modifiers, Strength.OpenLockedBarredOrMagicDoors);
      bendBarsLiftGates = GetModifier(modifiers, Strength.BendBarsLiftGates);

      return true;
    }

    public static bool TryGetConstitutionModifiers(int abilityScore
      )
    {
      if (!IsValidAbilityScore(abilityScore))
      {
        return false;
      }

      var modifiers = GetModifiers(Properties.Resources.Constitution, abilityScore);



      return true;
    }

    public static bool TryGetIntelligenceModifiers(int abilityScore)
    {
      if (!IsValidAbilityScore(abilityScore))
      {
        return false;
      }

      var modifiers = GetModifiers(Properties.Resources.Intelligence, abilityScore);

      return true;
    }

    public static bool TryGetWisdomModifiers(int abilityScore)
    {
      if (!IsValidAbilityScore(abilityScore))
      {
        return false;
      }

      var modifiers = GetModifiers(Properties.Resources.Wisdom, abilityScore);

      return true;
    }

    public static bool TryGetCharismaModifiers(int abilityScore)
    {
      if (!IsValidAbilityScore(abilityScore))
      {
        return false;
      }

      var modifiers = GetModifiers(Properties.Resources.Charisma, abilityScore);

      return true;
    }

    private static int GetModifier(JToken modifiers, Enum modifier)
    {
      return modifiers.Value<int>(modifier.ToString());
    }

    private static JToken GetModifiers(string statResource, int abilityScore, int? percentile = null)
    {
      var stat = JObject.Parse(statResource);
      var arrayIndexToStat = abilityScore - 1;
      return stat.GetValue(Modifiers)[arrayIndexToStat];
    }

    /// <summary>
    /// Checks validity of ability scores
    /// </summary>
    /// <param name="abilityScore"></param>
    /// <param name="percentile"> Used only for warrior's strength attribute</param>
    /// <returns></returns>
    private static bool IsValidAbilityScore(int abilityScore, int? percentile = null)
    {
      if (percentile.HasValue)
      {
        if (abilityScore != 18 || !IsValidPercentile(percentile.Value))
        {
          return false;
        }
      }
      return 0 < abilityScore && abilityScore < 26;
    }

    /// <summary>
    /// Check validity of percentile for warrior's strength score
    /// </summary>
    /// <param name="percentile"> Used only for warrior's strength attribute</param>
    /// <returns></returns>
    private static bool IsValidPercentile(int percentile)
    {
      return 0 < percentile && percentile < 101;
    }
  }
}
