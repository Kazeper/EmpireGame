using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public abstract class Event
	{
		public abstract string ShowInfo();

		/// <summary>
		/// increase or decrease morale according to event
		/// </summary>
		/// <param name="addedMorale"></param>
		public void AdjustMorale(int addedMorale)
		{
			Program.player.morale += addedMorale;
		}
	}
}