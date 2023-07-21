using Verse;

namespace DesalinationPlant;

public class CompProperties_DesalinationPlant : CompProperties
{
    public float waterPerTick;

    public CompProperties_DesalinationPlant()
    {
        compClass = typeof(CompDesalinationPlant);
    }
}