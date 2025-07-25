using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace DesalinationPlant;

public class PlaceWorker_DesalinationPlant : PlaceWorker
{
    public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
        Thing thingToIgnore = null, Thing thing = null)
    {
        var list = groundCells(loc, rot, out var waterCells);
        if (waterCells.Any(x => !isShallowOceanWater(x, map)))
        {
            return new AcceptanceReport("DP.MustBeOnShallowOceanWater".Translate());
        }

        if (list.Any(x => isWater(x, Find.CurrentMap)))
        {
            return new AcceptanceReport("DP.MustBeOnNonWaterGround".Translate());
        }

        return true;
    }

    private static bool isWater(IntVec3 loc, Map map)
    {
        return map.terrainGrid.TerrainAt(loc).IsWater;
    }

    private static bool isShallowOceanWater(IntVec3 loc, Map map)
    {
        return map.terrainGrid.TerrainAt(loc) == TerrainDefOf.WaterOceanShallow;
    }

    private static List<IntVec3> groundCells(IntVec3 loc, Rot4 rot, out List<IntVec3> waterCells)
    {
        var baseRect = CellRect.CenteredOn(loc, 5, 5);
        var source = baseRect.Cells.Where(x => !baseRect.GetEdgeCells(rot).Contains(x));
        waterCells = baseRect.GetEdgeCells(rot).ToList();
        return source.ToList();
    }

    public override void DrawGhost(ThingDef def, IntVec3 loc, Rot4 rot, Color ghostCol, Thing thing = null)
    {
        var list = groundCells(loc, rot, out var waterCells);
        var color = list.Any(x => isWater(x, Find.CurrentMap))
            ? Designator_Place.CannotPlaceColor.ToOpaque()
            : Designator_Place.CanPlaceColor.ToOpaque();
        GenDraw.DrawFieldEdges(list.ToList(), color);
        color = waterCells.Any(x => !isShallowOceanWater(x, Find.CurrentMap))
            ? Designator_Place.CannotPlaceColor.ToOpaque()
            : Designator_Place.CanPlaceColor.ToOpaque();
        GenDraw.DrawFieldEdges(waterCells, color);
    }
}