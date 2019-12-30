using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public class Circus : Event, ILuck
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
			int newCitizens = Program.random.Next(10, 26);
			Program.player.Population += newCitizens;
			return newCitizens;
		}

		/// <summary>
		/// returns proper morale information
		/// </summary>
		/// <returns></returns>
		public string MoraleInfo()
		{
			int newCitizens = IncreaseResources();
			AdjustMorale(1);
			return "Do twojej osady przyjechał cyrk! Ludzie szaleją!!! Morale rosną! Populacja wzrasta o " + newCitizens;
		}
	}
}