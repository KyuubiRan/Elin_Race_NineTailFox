using NineTailFox.Impl.Stances;
using NineTailFox.SourceDef.Races;

namespace NineTailFox.Impl.Abilities;

public class ActNTFMagicShield : Ability
{
    public override int ExpToNext => 1000 + vBase * 500;

    public override bool Perform()
    {
        if (TC?.Chara == null) return false;
        if (!CC.IsPC) return false;
        if (!RaceNineTailFox.PcRaceIsCurrent) return false;

        var chara = TC.Chara;
        
//         Plugin.Log.LogInfo(
//             $"""
//             vBase: {vBase}
//             vExp: {vExp}
//             vPotential: {vPotential}
//             vTempPotential: {vTempPotential}
//             vLink: {vLink}
//             vSource: {vSource}
//             vSourcePotential: {vSourcePotential}
//             Value: {Value}
//             ValueWithoutLink: {ValueWithoutLink}
//             """
//             );

        if (chara.HasCondition<StMagicShield>())
            chara.RemoveCondition<StMagicShield>();
        else
            chara.AddCondition<StMagicShield>();

        return true;
    }
}