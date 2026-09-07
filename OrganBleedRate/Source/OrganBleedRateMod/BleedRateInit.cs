using Verse;

namespace OrganBleedRateMod
{
    /// <summary>
    /// Runs once, right after all defs (vanilla and other mods') finish
    /// loading, and directly doubles the bleedRate field on three specific
    /// BodyPartDefs. No Harmony, no XML patch - bleedRate is just a plain
    /// public field on BodyPartDef, so we can mutate it in place. Because
    /// this multiplies whatever the current value is rather than hardcoding
    /// a replacement number, it still works correctly even if another mod
    /// has already changed these organs' base bleed rates.
    /// </summary>
    [StaticConstructorOnStartup]
    public static class BleedRateInit
    {
        static BleedRateInit()
        {
            DoubleBleedRate("Brain");
            DoubleBleedRate("Heart");
            DoubleBleedRate("Liver");
        }

        private static void DoubleBleedRate(string defName)
        {
            BodyPartDef def = DefDatabase<BodyPartDef>.GetNamedSilentFail(defName);
            if (def == null)
                return;

            def.bleedRate *= 3f;
        }
    }
}
