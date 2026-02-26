using System;
using JetBrains.Annotations;
using NineTailFox.I18n;

namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFElementRow : SourceElement.Row
{
    protected BaseNTFElementRow(int id, string alias, [CanBeNull] Type type = null)
    {
        this.id = id;
        this.alias = alias;
        this.type = (type ?? typeof(Element)).FullName;
        
        var tName = new TranslatedText($"element.{alias}.name", x => name = x);
        name_JP = tName.Value_JP;
        name = tName.Value;
        
        var tDetail = new TranslatedText($"element.{alias}.detail", x => detail = x);
        detail_JP = tDetail.Value_JP;
        detail = tDetail.Value;
        
        var tAltName = new TranslatedText($"element.{alias}.altname", x => altname = x);
        altname_JP = tAltName.Value_JP;
        altname = tAltName.Value;
        
        aliasParent = "";
        aliasRef = "";
        aliasMtp = "";
        encSlot = "";
        cost = [0];
        target = "";
        proc = [];
        group = "";
        category = "";
        categorySub = "";
        abilityType = [];
        tag = [];
        thing = "";
        req = [];
        idTrainer = "";
        tagTrainer = "";
        
        var tLevelBonus = new TranslatedText($"element.{alias}.levelBonus", x => levelBonus = x);
        levelBonus = tLevelBonus.Value;
        levelBonus_JP = tLevelBonus.Value_JP;
        
        foodEffect = [];
        langAct = [];
        
        var tTextPhase = new TranslatedText($"element.{alias}.textPhase", x => textPhase = x);
        textPhase_JP = tTextPhase.Value_JP;
        textPhase = tTextPhase.Value;
        
        var tTextExtra = new TranslatedText($"element.{alias}.textExtra", x => textExtra = x);
        textExtra_JP = tTextExtra.Value_JP;
        textExtra = tTextExtra.Value;
        
        var tTextInc = new TranslatedText($"element.{alias}.textInc", x => textInc = x);
        textInc_JP = tTextInc.Value_JP;
        textInc = tTextInc.Value;
        
        var tTextDec = new TranslatedText($"element.{alias}.textDec", x => textDec = x);
        textDec_JP = tTextDec.Value_JP;
        textDec = tTextDec.Value;
        
        textAlt_JP = [];
        textAlt = [];
        adjective_JP = [];
        adjective = [];
        mtp = 1;
        encFactor = 100;
        LV = 1;
        chance = 1000;
        geneSlot = 1;
        eleP = 50;
        charge = 10;
        radius = 5;
    }
}