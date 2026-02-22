using NineTailFox.Impl.Feats;
using NineTailFox.SourceDef.Base;

namespace NineTailFox.SourceDef.Feats;

public class FeatNineTailFox : BaseNTFFeatRow
{
    public static readonly FeatNineTailFox Instance = new();

    public FeatNineTailFox() : base(9999_9999, "FeatNineTailFox", typeof(FtNineTailFox))
    {
        parentFactor = 0;
        lvFactor = 0;
        LV = 1;
        max = 9;
        cost = [99999];
        tag = ["innate"];
    }
}