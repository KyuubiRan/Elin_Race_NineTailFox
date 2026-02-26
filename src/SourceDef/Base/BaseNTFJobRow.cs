using NineTailFox.I18n;

namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFJobRow : SourceJob.Row
{
    public BaseNTFJobRow(string id, int playable = 1)
    {
        this.id = id;
        this.playable = playable;

        var tName = new TranslatedText($"job.{id}.name", x => name = x);
        name_JP = tName.Value_JP;
        name = tName.Value;
        
        var tDetail = new TranslatedText($"job.{id}.detail", x => detail = x);
        detail_JP = tDetail.Value_JP;
        detail = tDetail.Value;

        elements = [];
        domain = [SKILL.eleFire, SKILL.eleCold, SKILL.eleLightning];
    }
}