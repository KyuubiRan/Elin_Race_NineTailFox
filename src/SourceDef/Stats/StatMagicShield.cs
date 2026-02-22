using NineTailFox.Impl.Stances;
using NineTailFox.SourceDef.Base;

namespace NineTailFox.SourceDef.Stats;

public class StatMagicShield : BaseNTFStatRow
{
    public static readonly StatMagicShield Instance = new();

    public StatMagicShield() : base(9999_0081, "StMagicShield", typeof(StMagicShield))
    {
        group = "Stance";
        colors = "stance";
    }
}