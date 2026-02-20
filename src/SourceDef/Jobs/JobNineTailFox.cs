using NineTailFox.SourceDef.Base;
using NineTailFox.SourceDef.Feats;

namespace NineTailFox.SourceDef.Jobs;

public class JobNineTailFox : BaseNTFJobRow
{
    public static readonly JobNineTailFox Instance = new();

    public JobNineTailFox() : base("JobNineTailFox")
    {
        name = "★九尾狐";
        name_JP = "★九尾の狐";

        equip = "mage";
        weapon = ["sword", "staff"];

        STR = 3;
        END = 3;
        DEX = 9;
        PER = 9;
        LER = 9;
        WIL = 9;
        MAG = 9;
        CHA = 9;

        elements =
        [
            FeatNineTailFox.Instance.id, +3, // nine tail fox feat

            ENC.r_life, -27, // life bonus ratio
            ENC.r_mana, +33, // mana bonus ratio

            FEAT.featManaBond, +3,
            FEAT.featManaPrecision, +3,
            FEAT.featFoxLearn, +3,
            SKILL.negotiation, +9, // negotiation
            SKILL.weaponSword, +3, // sword
            SKILL.weaponStaff, +9, // staff
            SKILL.controlmana, +9, // control mana
            SKILL.manaCapacity, +9, // mana capacity
            SKILL.casting, +9, // casting
            SKILL.reading, +9, // reading
            SKILL.magicDevice, +9, // magic device
            SKILL.meditation, +9, // meditation
            SKILL.appraising, +9, // appraising
            SKILL.memorization, +9, // memorization
            
            SKILL.resFire, +3, // fire resistance
            SKILL.resCold, +3, // ice resistance
        ];

        domain =
        [
            SKILL.eleMagic,

            SKILL.eleNether,
            SKILL.eleHoly,

            SKILL.eleChaos,
            SKILL.eleEther,

            SKILL.eleFire,
            SKILL.eleCold,
            SKILL.eleLightning,
        ];

        detail = "从异世界穿越而来的九尾狐，拥有强大的魔法力，但是代价是。。。";
        detail_JP = "異世界からやってきた九尾の狐。強力な魔法の力を持つが、その代償は。。。";
    }
}