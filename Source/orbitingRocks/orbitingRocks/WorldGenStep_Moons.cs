using System;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace ThatsAMoon
{
    // Token: 0x02000002 RID: 2
    public class WorldGenStep_Moons : WorldGenStep
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public override void GenerateFresh(string seed)
        {
            this.AddSmallMoon();
        }

        // Token: 0x06000002 RID: 2 RVA: 0x0000216F File Offset: 0x0000036F
        public override void GenerateFromScribe(string seed)
        {
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002174 File Offset: 0x00000374
        private void AddSmallMoon()
        {
            WorldObject_SmallMoon worldObject_SmallMoon = (WorldObject_SmallMoon)WorldObjectMaker.MakeWorldObject(DefDatabase<WorldObjectDef>.GetNamed("SmallMoon", true));
            worldObject_SmallMoon.Tile = TileFinder.RandomStartingTile();
            worldObject_SmallMoon.Periapsis = new Vector3(200f, 50f, 0f);
            worldObject_SmallMoon.Apoapsis = new Vector3(-200f, -50f, 0f);
            worldObject_SmallMoon.period = 60000;
            Find.WorldObjects.Add(worldObject_SmallMoon);
        }
    }
}
