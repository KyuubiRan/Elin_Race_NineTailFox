using NineTailFox.Impl.Abilities;
using NineTailFox.SourceDef.Base;

namespace NineTailFox.SourceDef.Abilities;

public class AbilityMagicShield : BaseNTFElementRow
{
    public static readonly AbilityMagicShield Instance = new();

    public AbilityMagicShield() : base(9999_9981, "ActNTFMagicShield", typeof(ActNTFMagicShield))
    {
        name = "魔力护盾";
        name_JP = "マジックシールド";
        aliasParent = "MAG";
        parentFactor = 5;
        LV = 1;
        chance = 0;
        value = 0;
        cost = [0];
        target = "Self";
        group = "ABILITY";
        category = "ability";
        categorySub = "ability";
        tag = ["noRandomAbility", "specialAbility"];
        detail = "（独有能力）使用魔力来抵消伤害，等级越高消耗的魔力越少。";
        detail_JP = "『ユニークアビリティ』魔力を消費してダメージを軽減する。レベルが高いほど消費する魔力が少なくなる。";
        textExtra = "受到任意类型伤害时，消耗魔力抵消伤害。";
        textExtra_JP = "あらゆるタイプのダメージを受けると、魔力を消費してダメージを軽減する。";
    }
}