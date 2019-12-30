using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public class HeavyRain : Event, ICataclysm
	{
		/// <summary>
		/// returns proper event info
		/// </summary>
		/// <returns></returns>
		public override string ShowInfo()
		{
			double destroyPercentage = DestroyResource();
			string info = "O0o nie! Przez intensywne opady straciłeś " + destroyPercentage + "% chleba oraz morale";
			return info;
		}

		/// <summary>
		/// decrease resources according to cataclysm
		/// </summary>
		/// <returns></returns>
		public double DestroyResource()
		{
			double rand = Program.random.NextDouble();
			double destroyPercentage = Math.Round(((rand * 100) % 10 + 10), 0);
			Program.player.Bread -= (int)((double)Program.player.Bread * destroyPercentage / 100);
			AdjustMorale(-1);
			return destroyPercentage;
		}
	}
}