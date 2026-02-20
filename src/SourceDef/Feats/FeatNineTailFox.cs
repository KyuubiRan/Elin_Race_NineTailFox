using NineTailFox.Impl.Feats;
using NineTailFox.SourceDef.Base;

namespace NineTailFox.SourceDef.Feats;

public class FeatNineTailFox : BaseNTFFeatRow
{
    public static readonly FeatNineTailFox Instance = new();

    public FeatNineTailFox() : base(9999_9999, "featNineTailFox", typeof(FtNineTailFox))
    {
        name = "九尾狐";
        name_JP = "九尾の狐";
        parentFactor = 0;
        lvFactor = 0;
        LV = 1;
        max = 9;
        cost = [99999];
        tag = ["innate"];

        detail = """
                 你是九尾狐，拥有强大的魔法力，正因如此：
                 * 你的生命力倍率变得极低，但是你的玛那倍率极高。
                 * 你的魔法永远不会枯竭，但是在存量较低时会增加魔力消耗。
                 * 你能造成更高的魔法伤害。
                 * 你拥有使用魔力抵消伤害的能力。
                 * 你对火焰和寒冷的抗性增加。
                 * 你拥有很高的阅历。
                 """;
        detail_JP = """
                    あなたは九尾の狐であり、強力な魔法の力を持っています。そのため：
                    * あなたの生命力倍率は非常に低くなりますが、マナ倍率は非常に高くなります。
                    * あなたの魔力は決して枯渇しませんが、残量が少ないときは魔力消費が増加します。
                    * あなたはより高い魔法ダメージを与えることができます。
                    * あなたは魔力を消費してダメージを軽減する能力を持っています。
                    * あなたの火と氷に対する耐性が増加します。
                    * あなたは非常に豊富な経験をお持ちです。
                    """;

        textPhase = "你是九尾狐！";
        textExtra_JP = "あなたは九尾の狐だ！";

        textExtra = "尾大，无需多言！";
        textExtra_JP = "九尾の加護！";
    }
}