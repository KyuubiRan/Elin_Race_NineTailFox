namespace NineTailFox.SourceDef.Base;

public abstract class BaseNTFRaceRow : SourceRace.Row
{
    protected BaseNTFRaceRow(string id, int playable = 1)
    {
        this.id = id;
        this.playable = playable;
        name_JP = "";
        name = "";
        vigor = 100;
        DV = 0;
        PV = 0;
        tag = [];
        elements = [];
        skill = "";
        figure = "頭|首|体|背|手|手|指|指|腕|腰|脚|足|";
        geneCap = 3;
        material = "meat";
        martial = 2;
        blood = 2;
        corpse = ["_meat", "0"];
        loot = [];
        EQ = ["all"];
        age = [8, 50];
        height = 150;
        breeder = 100;
        food = ["100"];
        fur = "";
        detail_JP = "";
        detail = "";
    }
}