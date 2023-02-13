using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rimefeller;
using Verse;
using RimWorld;
using UnityEngine;
using PipeSystem;
using Verse.Sound;

namespace Chemfuelfeller
{
	public class ChemPump : CompPipe
	{

		public new CompProperties_FuelPump Props
		{
			get
			{
				return (CompProperties_FuelPump)this.props;
			}
		}

		public virtual bool WorkingNow
		{
			get
			{
				return FlickUtility.WantsToBeOn(this.parent) && (this.powerComp == null || this.powerComp.PowerOn) && (this.breakdownableComp == null || !this.breakdownableComp.BrokenDown);
			}
		}

		public override void PostSpawnSetup(bool respawningAfterLoad)
		{
			base.PostSpawnSetup(respawningAfterLoad);
			this.powerComp = this.parent.GetComp<CompPowerTrader>();
			this.breakdownableComp = this.parent.GetComp<CompBreakdownable>();
		}

		public override void CompTick()
		{
			base.CompTick();
			if (this.parent.IsHashIntervalTick(60) && base.pipeNet.TotalFuel >= (double)this.Props.pumpRate && this.MapComp.UnderFuelLimit() && this.WorkingNow)
			{

				int num = Mathf.Min(MaxCanInput, this.Props.pumpRate);
				if (num > 0)
				{
					base.pipeNet.PullFuel((double)num);
					PipeNet.DistributeAmongStorage(num);
					//Input to pipenet
				}

			}
		}

		public CompPowerTrader powerComp;

		public CompBreakdownable breakdownableComp;

		public int MaxCanInput => (int)PipeNet.AvailableCapacity;
		public virtual PipeNet PipeNet { get; set; }


		//Messy as fuck code. All the Vanilla Pipework stuff being used to make it work.

	}

	public class ConvertResource : ThingComp
    {
		CompPipe compPipe = new CompPipe();
    }
}
