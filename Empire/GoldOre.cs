using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public class GoldOre : Event, ILuck
	{
		/// <summary>
		/// returns proper event info
		/// </summary>
		/// <returns></returns>
		public override string ShowInfo()
		{
			return MoraleInfo();
		}

		/// <summary>
		/// increases resources according to event
		/// </summary>
		/// <returns></returns>
		public int IncreaseResources()
		{
			int gold = Program.random.Next(1000, 2001);
			Program.player.Cash += gold;
			return gold;
		}

		/// <summary>
		/// returns proper morale information
		/// </summary>
		/// <returns></returns>
		public string MoraleInfo()
		{
			int gold = IncreaseResources();
			AdjustMorale(1);
			return "Górnicy znaleźli żyłę złota! Zyskujesz " + gold + " golda oraz morale!";
		}
	}
}