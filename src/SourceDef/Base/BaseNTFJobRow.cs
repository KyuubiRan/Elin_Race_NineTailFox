using NineTailFox.I18n;

namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFJobRow : SourceJob.Row
{
    private TranslatedText _tName;
    private TranslatedText _tDetail;

    public BaseNTFJobRow(string id, int playable = 1)
    {
        this.id = id;
        this.playable = playable;

        _tName = new TranslatedText($"job.{id}.name", x => name = x);
        name_JP = _tName.Value_JP;
        name = _tName.Value;
        
        _tDetail = new TranslatedText($"job.{id}.detail", x => detail = x);
        detail_JP = _tDetail.Value_JP;
        detail = _tDetail.Value;

        elements = [];
        domain = [SKILL.eleFire, SKILL.eleCold, SKILL.eleLightning];
    }
}