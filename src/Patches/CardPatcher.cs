using System;
using HarmonyLib;
using NineTailFox.Impl.Stances;
using NineTailFox.SourceDef.Abilities;
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

        var lvl = ab.vBase;

        // lvl <= 1: 0.5 damage/mana
        // lvl = 50: 1.0 damage/mana
        // lvl >= 100: 2.0 damage/mana
        var damageReducePerMana =
            lvl <= 1 ? 0.5f :
            lvl >= 100 ? 2.0f :
            0.5f + (lvl - 1) * (1.5f / 99f);

        var manaToUse = Math.Max(1, (int)Math.Round(dmg / damageReducePerMana));
        if (manaToUse > charMana)
            manaToUse = charMana;

        var damageReduce = (int)(manaToUse * damageReducePerMana);
        dmg -= damageReduce;
        c.mana.value -= manaToUse;
        c.elements.ModExp(ab.id, manaToUse);
        // Plugin.Log.LogInfo("MS mod exp: +" + manaToUse + ", exp: " + ab.vExp + ",  lvl: " + ab.vBase + ", next lvl exp: " + ab.ExpToNext);
    }
}