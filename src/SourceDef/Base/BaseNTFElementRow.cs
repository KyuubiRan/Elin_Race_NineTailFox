using System;
using JetBrains.Annotations;
using NineTailFox.I18n;
using UnityEngine.UIElements;

namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFElementRow : SourceElement.Row
{
    private TranslatedText _tName;
    private TranslatedText _tDetail;
    private TranslatedText _tAltName;
    private TranslatedText _tTextPhase;
    private TranslatedText _tTextExtra;
    private TranslatedText _tTextInc;
    private TranslatedText _tTextDec;
    private TranslatedText _tLevelBonus;

    protected BaseNTFElementRow(int id, string alias, [CanBeNull] Type type = null)
    {
        this.id = id;
        this.alias = alias;
        this.type = (type ?? typeof(Element)).FullName;
        _tName = new TranslatedText($"element.{alias}.name", x => name = x);
        name_JP = _tName.Value_JP;
        name = _tName.Value;
        _tAltName = new TranslatedText($"element.{alias}.altname", x => altname = x);
        altname_JP = _tAltName.Value_JP;
        altname = _tAltName.Value;
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
        levelBonus = "";
        levelBonus_JP = "";
        foodEffect = [];
        langAct = [];
        _tDetail = new TranslatedText($"element.{alias}.detail", x => detail = x);
        detail_JP = _tDetail.Value_JP;
        detail = _tDetail.Value;
        _tTextPhase = new TranslatedText($"element.{alias}.textPhase", x => textPhase = x);
        textPhase_JP = _tTextPhase.Value_JP;
        textPhase = _tTextPhase.Value;
        _tTextExtra = new TranslatedText($"element.{alias}.textExtra", x => textExtra = x);
        textExtra_JP = _tTextExtra.Value_JP;
        textExtra = _tTextExtra.Value;
        _tTextInc = new TranslatedText($"element.{alias}.textInc", x => textInc = x);
        textInc_JP = _tTextInc.Value_JP;
        textInc = _tTextInc.Value;
        _tTextDec = new TranslatedText($"element.{alias}.textDec", x => textDec = x);
        textDec_JP = _tTextDec.Value_JP;
        textDec = _tTextDec.Value;
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