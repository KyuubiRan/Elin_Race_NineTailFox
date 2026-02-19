namespace NineTailFox;

public static class NineTailFoxLoader
{
    private static SourceManager SM => EClass.sources;

    public static void Add(SourceElement.Row row) => SM.elements.rows.Add(row);
    public static void Add(SourceRace.Row row) => SM.races.rows.Add(row);
    public static void Add(SourceJob.Row row) => SM.jobs.rows.Add(row);
    public static void Add(SourceThing.Row row) => SM.things.rows.Add(row);
    public static void Add(SourceThingV.Row row) => SM.thingV.rows.Add(row);
    public static void Add(SourceStat.Row row) => SM.stats.rows.Add(row);
}