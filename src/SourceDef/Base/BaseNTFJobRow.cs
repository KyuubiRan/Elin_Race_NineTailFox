namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFJobRow : SourceJob.Row
{
    public BaseNTFJobRow(string id, int playable = 1)
    {
        this.id = id;
        this.playable = playable;
        name_JP = "";
        name = "";

        elements = [];
        domain = [SKILL.eleFire, SKILL.eleCold, SKILL.eleLightning];
    }
}