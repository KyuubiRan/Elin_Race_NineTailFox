using System;
using JetBrains.Annotations;

namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFStatRow : SourceStat.Row
{
    protected BaseNTFStatRow(int id, string alias, [CanBeNull] Type type = null)
    {
        this.id = id;
        this.alias = alias;
        this.type = type?.FullName;
        name_JP = "";
        name = "";
        group = "Neutral";
        curse = "";
        duration = "p/10";
        hexPower = 10;
        negate = [];
        defenseAttb = [];
        resistance = [];
        elements = [];
        nullify = [];
        tag = [];
        phase = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
        effect = [];
        strPhase_JP = [];
        strPhase = [];
        textPhase_JP = "";
        textPhase = "";
        textEnd_JP = "";
        textEnd = "";
        textPhase2_JP = "";
        textPhase2 = "";
        gradient = "condition";
        detail_JP = "";
        detail = "";
    }
}