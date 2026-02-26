using System;
using JetBrains.Annotations;
using NineTailFox.I18n;

namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFStatRow : SourceStat.Row
{
    protected BaseNTFStatRow(int id, string alias, [CanBeNull] Type type = null)
    {
        this.id = id;
        this.alias = alias;
        this.type = type?.FullName;
        
        var tName = new TranslatedText($"stat.{alias}.name", x => name = x);
        name_JP = tName.Value_JP;
        name = tName.Value;
        
        var tDetail = new TranslatedText($"stat.{alias}.detail", x => detail = x);
        detail_JP = tDetail.Value_JP;
        detail = tDetail.Value;
    
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
        
        var tTextPhase = new TranslatedText($"stat.{alias}.textPhase", x => textPhase = x);
        textPhase_JP = tTextPhase.Value_JP;
        textPhase = tTextPhase.Value;
   
        var tTextEnd = new TranslatedText($"stat.{alias}.textEnd", x => textEnd = x);
        textEnd_JP = tTextEnd.Value_JP;
        textEnd = tTextEnd.Value;
   
        var tTextPhase2 = new TranslatedText($"stat.{alias}.textPhase2", x => textPhase2 = x);
        textPhase2_JP = tTextPhase2.Value_JP;
        textPhase2 = tTextPhase2.Value;
    
        gradient = "condition";
    }
}