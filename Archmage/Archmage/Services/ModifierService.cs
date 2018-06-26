namespace Archmage.Services
{
    public static class ModifierService
    {
      public static string ModifierSymbol(int modifier)
      {
        return modifier >= 0 ? "+" : "-";
      }
  }
}
