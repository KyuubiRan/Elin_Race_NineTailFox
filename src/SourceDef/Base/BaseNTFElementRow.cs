using System;
using JetBrains.Annotations;

namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFElementRow : SourceElement.Row
{
    protected BaseNTFElementRow(int id, string alias, [CanBeNull] Type type = null)
    {
        this.id = id;
        this.alias = alias;
        this.type = (type ?? typeof(Element)).FullName;
        name_JP = "";
        name = "";
        altname_JP = "";
        altname = "";
        aliasParent = "";
        aliasRef = "";
        aliasMtp = "";
        encSlot = "";
        cost = [];
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
        detail_JP = "";
        detail = "";
        textPhase_JP = "";
        textPhase = "";
        textExtra_JP = "";
        textExtra = "";
        textInc_JP = "";
        textInc = "";
        textDec_JP = "";
        textDec = "";
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