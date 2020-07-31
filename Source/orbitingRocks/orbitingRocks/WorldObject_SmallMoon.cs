using System;
using System.Reflection;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace ThatsAMoon
{
    // Token: 0x02000006 RID: 6
    [StaticConstructorOnStartup]
    public class WorldObject_SmallMoon : WorldObject
    {
        // Token: 0x17000004 RID: 4
        // (get) Token: 0x06000023 RID: 35 RVA: 0x000028AE File Offset: 0x00000AAE
        public override Vector3 DrawPos
        {
            get
            {
                return Vector3.SlerpUnclamped(this.Periapsis, this.Apoapsis, this.traveledPct);
            }
        }

        // Token: 0x06000024 RID: 36 RVA: 0x00002375 File Offset: 0x00000575
        public override void PostAdd()
        {
            base.PostAdd();
        }

        // Token: 0x06000025 RID: 37 RVA: 0x000028C8 File Offset: 0x00000AC8
        internal static object GetInstanceField(Type type, object instance, string fieldName)
        {
            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            return type.GetField(fieldName, bindingAttr).GetValue(instance);
        }

        // Token: 0x06000026 RID: 38 RVA: 0x000028E8 File Offset: 0x00000AE8
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<int>(ref this.period, "period", 0, false);
            Scribe_Values.Look<float>(ref this.traveledPct, "traveledPct", 0f, false);
            Scribe_Values.Look<Vector3>(ref this.Periapsis, "Periapsis", default(Vector3), false);
            Scribe_Values.Look<Vector3>(ref this.Apoapsis, "Apoapsis", default(Vector3), false);
            WorldObject_SmallMoon.GetInstanceField(typeof(WorldObject), this, "BaseDrawSize");
        }

        // Token: 0x06000027 RID: 39 RVA: 0x0000296D File Offset: 0x00000B6D
        public override void Tick()
        {
            base.Tick();
            this.traveledPct += GenMath.SphericalDistance(this.Periapsis.normalized, this.Apoapsis.normalized) / (float)this.period;
        }

        // Token: 0x06000028 RID: 40 RVA: 0x000029A8 File Offset: 0x00000BA8
        public override void Print(LayerSubMesh subMesh)
        {
            float averageTileSize = Find.WorldGrid.averageTileSize;
            WorldRendererUtility.PrintQuadTangentialToPlanet(this.DrawPos, 1.7f * averageTileSize, 0.008f, subMesh, false, false, true);
        }

        // Token: 0x06000029 RID: 41 RVA: 0x000029DC File Offset: 0x00000BDC
        public override void Draw()
        {
            float averageTileSize = Find.WorldGrid.averageTileSize;
            float transitionPct = ExpandableWorldObjectsUtility.TransitionPct;
            if (this.def.expandingIcon && transitionPct > 0f)
            {
                Color color = this.Material.color;
                MaterialPropertyBlock materialPropertyBlock = WorldObject_SmallMoon.propertyBlock;
                WorldRendererUtility.DrawQuadTangentialToPlanet(this.DrawPos, 0.7f * averageTileSize, 0.008f, this.Material, false, false, null);
                return;
            }
            WorldRendererUtility.DrawQuadTangentialToPlanet(this.DrawPos, 0.7f * averageTileSize, 0.008f, this.Material, false, false, null);
        }

        // Token: 0x04000010 RID: 16
        private float traveledPct;

        // Token: 0x04000011 RID: 17
        public Vector3 Periapsis;

        // Token: 0x04000012 RID: 18
        public Vector3 Apoapsis;

        // Token: 0x04000013 RID: 19
        public int period;

        // Token: 0x04000014 RID: 20
        private static MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
    }
}
