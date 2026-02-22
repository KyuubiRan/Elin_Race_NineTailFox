using NineTailFox.Impl.Base;
using NineTailFox.SourceDef.Abilities;

namespace NineTailFox.Impl.Feats;

public class FtNineTailFox : BaseNTFFeat
{
    public override void ApplyPost(int v, ElementContainer ownerContainer, bool hint = false)
    {
        ModBase(AbilityMagicShield.Instance.id, v, false, hint);

        ModPotential(SKILL.STR, v * 11, hint);
        ModPotential(SKILL.END, v * 11, hint);
        ModPotential(SKILL.DEX, v * 11, hint);
        ModPotential(SKILL.PER, v * 11, hint);
        ModPotential(SKILL.LER, v * 11, hint);
        ModPotential(SKILL.WIL, v * 11, hint);
        ModPotential(SKILL.MAG, v * 11, hint);
        ModPotential(SKILL.CHA, v * 11, hint);
    }
}