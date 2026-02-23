using System;
using HarmonyLib;
using NineTailFox.Impl.Stances;
using NineTailFox.SourceDef.Abilities;
using NineTailFox.SourceDef.Feats;
using NineTailFox.SourceDef.Races;

namespace NineTailFox.Patches;

[HarmonyPatch(typeof(Card))]
public class CardPatcher
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Card.DamageHP),
        typeof(long),
        typeof(int),
        typeof(int),
        typeof(AttackSource),
        typeof(Card),
        typeof(bool),
        typeof(Thing),
        typeof(Chara)
    )]
    static void DamageHP_Prefix(Card __instance,
        ref long dmg,
        int ele,
        int eleP,
        AttackSource attackSource,
        Card origin,
        bool showEffect,
        Thing weapon,
        Chara originalTarget
    )
    {
        if (!__instance.isChara || !__instance.IsPC)
            return;

        var c = __instance.Chara;

        if (c.race.id != RaceNineTailFox.Instance.id)
            return;

        if (!__instance.HasCondition<StMagicShield>())
            return;

        var ab = c.elements.GetElement(AbilityMagicShield.Instance.id);
        if (ab == null)
            return;

        var charMana = c.mana.value;
        if (charMana <= 0)
            return;

        var lvl = ab.Value;

        var mod = Math.Max(1, c.Evalue(FeatNineTailFox.Instance.id));

        // lvl <= 1: 0.5 damage/mana
        // lvl = 50: 1.0 damage/mana
        // lvl >= 100: 2.0 damage/mana
        var damageReducePerMana =
            lvl <= 1 ? 0.5 :
            lvl >= 100 ? 2.0 :
            0.5 + (lvl - 1) * (1.5 / 99);
        damageReducePerMana *= 1 + mod * 0.09; // 每级mod增加9%效率
        
        var manaToUse = Math.Max(1, (int)Math.Ceiling(dmg / damageReducePerMana));
        if (manaToUse > charMana)
            manaToUse = charMana;

        var damageReduce = (long)(manaToUse * damageReducePerMana);
        dmg -= damageReduce;

        c.mana.value -= manaToUse;
        var modExp = manaToUse * mod;
        c.elements.ModExp(ab.id, modExp);
        // Plugin.LogInfo("MS mod exp: +" + modExp + ", exp: " + ab.vExp + ",  base lvl: " + ab.vBase + ", next lvl exp: " + ab.ExpToNext);
    }
}