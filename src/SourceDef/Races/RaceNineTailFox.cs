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
        
        STR = 6;
        END = 6;
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
            ENC.r_life, -54, // life bonus ratio
            ENC.r_mana, +66, // mana bonus ratio
            ENC.sustain_MAG, +1, // sustain magic
            ENC.meleeDistance, +1, // melee distance

            FeatNineTailFox.Instance.id, +6, // nine tail fox feat
            
            FEAT.featManaBond, +6,
            FEAT.featManaPrecision, +6,
            FEAT.featFoxLearn, +6,
            SKILL.negotiation, +9, // negotiation
            SKILL.weaponSword, +6, // sword
            SKILL.weaponStaff, +9, // staff
            SKILL.controlmana, +9, // control mana
            SKILL.manaCapacity, +9, // mana capacity
            SKILL.reading, +9, // reading
            SKILL.casting, +9, // casting
            SKILL.magicDevice, +9, // magic device
            SKILL.meditation, +9, // meditation
            SKILL.appraising, +9, // appraising
            SKILL.memorization, +9, // memorization

            SKILL.resFire, +6, // fire resistance
            SKILL.resCold, +6, // ice resistance
        ];
        age = [999, 999];
        figure = "頭|首|体|背|手|手|指|指|腕|腰|脚|足|";
        geneCap = 9;
        detail = "从异世界穿越而来的九尾狐，拥有强大的魔法力，但是代价是。。。";
        detail_JP = "異世界からやってきた九尾の狐。強力な魔法の力を持つが、その代償は。。。";
    }
}