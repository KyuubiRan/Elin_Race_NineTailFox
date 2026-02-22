using System;
using JetBrains.Annotations;
using NineTailFox.I18n;

namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFStatRow : SourceStat.Row
{
    private TranslatedText _tName;
    private TranslatedText _tDetail;
    private TranslatedText _tTextPhase;
    private TranslatedText _tTextEnd;
    private TranslatedText _tTextPhase2;

    protected BaseNTFStatRow(int id, string alias, [CanBeNull] Type type = null)
    {
        this.id = id;
        this.alias = alias;
        this.type = type?.FullName;
        
        _tName = new TranslatedText($"stat.{alias}.name", x => name = x);
        name_JP = _tName.Value_JP;
        name = _tName.Value;
        
        _tDetail = new TranslatedText($"stat.{alias}.detail", x => detail = x);
        detail_JP = _tDetail.Value_JP;
        detail = _tDetail.Value;
    
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
        
        _tTextPhase = new TranslatedText($"stat.{alias}.textPhase", x => textPhase = x);
        textPhase_JP = _tTextPhase.Value_JP;
        textPhase = _tTextPhase.Value;
   
        _tTextEnd = new TranslatedText($"stat.{alias}.textEnd", x => textEnd = x);
        textEnd_JP = _tTextEnd.Value_JP;
        textEnd = _tTextEnd.Value;
   
        _tTextPhase2 = new TranslatedText($"stat.{alias}.textPhase2", x => textPhase2 = x);
        textPhase2_JP = _tTextPhase2.Value_JP;
        textPhase2 = _tTextPhase2.Value;
    
        gradient = "condition";
    }
}