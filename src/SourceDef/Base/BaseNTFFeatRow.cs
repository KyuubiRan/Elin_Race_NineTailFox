using System;
using JetBrains.Annotations;

namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFFeatRow : BaseNTFElementRow
{
    protected BaseNTFFeatRow(int id, string alias, [CanBeNull] Type type = null) : base(id, alias, type ?? typeof(Feat))
    {
        group = "FEAT";
        category = "feat";
        tag = [];
        cost = [0];
        max = 1;
    }
}