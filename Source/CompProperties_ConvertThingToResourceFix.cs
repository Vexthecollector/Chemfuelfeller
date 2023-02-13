using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using PipeSystem;

namespace Chemfuelfeller
{
    internal class CompProperties_ConvertThingToResourceFix : CompProperties_Resource
    {
        public CompProperties_ConvertThingToResourceFix()
        {
            compClass = typeof(CompConvertToResourceFix);
        }

        public int ratio = 1;
        public ThingDef thing;

        public override IEnumerable<string> ConfigErrors(ThingDef parentDef)
        {
            foreach (string err in base.ConfigErrors(parentDef))
                yield return err;

            if (parentDef.thingClass != typeof(Building_Storage))
                yield return "Can't use CompProperties_ConvertThingToResource with a thing that don't have Building_Storage as thingClass.";
            if (parentDef.comps.FindAll(c => c is CompProperties_ConvertThingToResource).Count > 1)
                yield return "Can't use multiple CompProperties_ConvertThingToResource on the same thing.";
            if (thing == null)
                yield return "Can't use CompProperties_ConvertThingToResource with a null thing.";
        }
    }
}
