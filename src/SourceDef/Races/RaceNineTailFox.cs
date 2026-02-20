using NineTailFox.SourceDef.Abilities;
using NineTailFox.SourceDef.Base;
using NineTailFox.SourceDef.Feats;

namespace NineTailFox.SourceDef.Races;

public class RaceNineTailFox : BaseNTFRaceRow
{
    public static readonly RaceNineTailFox Instance = new();

    public static bool PcRaceIsCurrent => EClass.pc?.race.id == Instance.id;

    public RaceNineTailFox() : base("RaceNineTailFox")
    {
        name = "★九尾狐";
        name_JP = "★九尾の狐";
        tag = ["god", "humanSpeak", "mofu"];
        life = 33;
        mana = 200;
        vigor = 100;
        SPD = 200;
        STR = 1;
        END = 1;
        DEX = 9;
        PER = 9;
        LER = 9;
        WIL = 9;
        MAG = 9;
        CHA = 9;
        height = 160;
        breeder = 100;
        EQ = ["all"];
        loot = ["tail_fox", "10"];
        food = ["120"];
        elements =
        [
            AbilityMagicShield.Instance.id, 1, // magic shield

            ENC.r_life, -45, // life bonus ratio
            ENC.r_mana, +66, // mana bonus ratio
            ENC.sustain_MAG, +1, // sustain magic
            ENC.meleeDistance, +1, // melee distance

            FeatNineTailFox.Instance.id, +5, // nine tail fox feat
            FEAT.featAnimalLover, +1, // animal lover
            FEAT.featManaBond, +9, // mana bond
            FEAT.featManaPrecision, +9, // mana precision
            FEAT.featFastLearner, +3, // fast learner
            FEAT.featFoxLearn, +9, // fox learn
            FEAT.featFoxMaid, +9, // fox learn
            FEAT.featRoran, +1, // roran
            FEAT.featElder, +1, // elder

            SKILL.travel, +9, // travel
            SKILL.negotiation, +9, // negotiation
            SKILL.weaponSword, +6, // sword
            SKILL.weaponStaff, +9, // staff
            SKILL.reading, +9, // reading
            SKILL.casting, +9, // casting
            SKILL.magicDevice, +9, // magic device
            SKILL.meditation, +9, // meditation
            SKILL.appraising, +9, // appraising
            SKILL.memorization, +9, // memorization

            SKILL.resFire, +9, // fire resistance
            SKILL.resCold, +9, // ice resistance
        ];
        age = [999, 999];
        figure = "頭|首|体|背|手|手|指|指|腕|腰|脚|足|";
        geneCap = 9;
        detail = "从异世界穿越而来的九尾狐，拥有强大的魔法力，但是代价是。。。";
        detail_JP = "異世界からやってきた九尾の狐。強力な魔法の力を持つが、その代償は。。。";
    }
}