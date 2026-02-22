using NineTailFox.Impl.Abilities;
using NineTailFox.SourceDef.Base;

namespace NineTailFox.SourceDef.Abilities;

public class AbilityMagicShield : BaseNTFElementRow
{
    public static readonly AbilityMagicShield Instance = new();

    public AbilityMagicShield() : base(9999_9981, "ActNTFMagicShield", typeof(ActNTFMagicShield))
    {
        aliasParent = "MAG";
        parentFactor = 5;
        chance = 0;
        value = 0;
        cost = [0];
        target = "Self";
        group = "ABILITY";
        category = "ability";
        categorySub = "ability";
        tag = ["specialAbility", "noRandomAbility"];
    }
}