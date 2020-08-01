using RimWorld;
using Verse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biomeMoon
{
    public class WorldGen_bm : GenStep_RocksFromGrid
    {
        public override GenStep_RocksFromGrid()
        {
            return false;
        }
    }
}
