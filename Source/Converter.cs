using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Rimefeller;
using PipeSystem;
using Verse;

namespace Chemfuelfeller
{
    public class Converter
    {
       

        public class input
        {
            public int amount;
            public ThingDef thing;

            public PipeNetDef net;
            public int netCount;
        }

        public class output
        {
            public int amount;
            public ThingDef thing;
        }
    }
}
