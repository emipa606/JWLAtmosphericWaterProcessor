using DubsBadHygiene;
using RimWorld;
using Verse;

namespace DesalinationPlant;

public class CompDesalinationPlant : ThingComp
{
    private CompPipe compPipe;

    private CompPowerTrader compPower;

    public CompProperties_DesalinationPlant Props => props as CompProperties_DesalinationPlant;

    public override void PostSpawnSetup(bool respawningAfterLoad)
    {
        base.PostSpawnSetup(respawningAfterLoad);
        compPipe = parent.GetComp<CompPipe>();
        compPower = parent.GetComp<CompPowerTrader>();
    }

    public override void CompTick()
    {
        base.CompTick();
        if (compPower.PowerOn)
        {
            compPipe.pipeNet.PushWater(Props.waterPerTick);
        }
    }
}