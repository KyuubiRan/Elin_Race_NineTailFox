using NineTailFox.Impl.Stances;
using NineTailFox.SourceDef.Base;

namespace NineTailFox.SourceDef.Stats;

public class StatMagicShield : BaseNTFStatRow
{
    public static readonly StatMagicShield Instance = new();

    public StatMagicShield() : base(9999_0081, "StMagicShield", typeof(StMagicShield))
    {
        name = "魔力护盾";
        name_JP = "マジックシールド";
        detail = "你感受到魔力护盾环绕自身。";
        detail_JP = "あなたはマジックシールドを感じる。";
        group = "Stance";
        colors = "stance";
    }
}