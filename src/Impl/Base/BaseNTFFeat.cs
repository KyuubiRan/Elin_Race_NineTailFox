using UnityEngine;

namespace NineTailFox.Impl.Base;

public abstract class BaseNTFFeat : Feat
{
    public virtual void ApplyPre(int v, ElementContainer ownerContainer, bool hint = false)
    {
    }

    public virtual void ApplyPost(int v, ElementContainer ownerContainer, bool hint = false)
    {
    }
    
    protected void Note(string s, bool hint = false)
    {
        if (!hint)
            return;
        hints.Add(s);
    }

    protected void NoteElement(int ele, int a)
    {
        var row = sources.elements.map[ele];
        if (row.category == "ability")
            Note("hintLearnAbility".lang(row.GetName().ToTitleCase()));
        else if (row.tag.Contains("flag"))
        {
            Note(row.GetName());
        }
        else
        {
            var ref2_1 = (a < 0 ? "" : "+") + a;
            if (row.category == "resist")
            {
                var num = 0;
                var ref2_2 = (a > 0 ? "+" : "-").Repeat(Mathf.Clamp(Mathf.Abs(a) / 5 + num, 1, 5));
                Note("modValueRes".lang(row.GetName(), ref2_2));
            }
            else
                Note("modValue".lang(row.GetName(), ref2_1));
        }
    }

    protected void ModBase(int ele, int v, bool hide, bool hint = false)
    {
        if (!hint)
            owner.ModBase(ele, v);
        if (hide || v == 0)
            return;
        NoteElement(ele, v);
    }

    protected void ModPotential(int ele, int v, bool hint = false)
    {
        if (!hint)
            owner.ModPotential(ele, v);
        Note("modPotential".lang(sources.elements.map[ele].GetName(), $"+{v.ToString()}%"));
    }

    protected void ModAttribute(int ele, int v, bool hint = false)
    {
        var a = Mathf.Abs(v);
        var invert = v >= 0 ? 1 : -1;
        ModBase(ele, a switch
        {
            1 => 2,
            2 => 4,
            _ => 5
        } * invert, false);
        ModPotential(ele, v * 10);
    }

    protected void GodHint(bool hint = false)
    {
        if (!hint)
            return;
        foreach (var element in owner.Card.Chara.faithElements.dict.Values)
        {
            if (element.source.id != this.id)
                NoteElement(element.id, element.Value);
        }
    }
}