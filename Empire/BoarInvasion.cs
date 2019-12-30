using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public class BoarInvasion : Event, IInvasion
	{
		/// <summary>
		/// returns proper event info
		/// </summary>
		/// <returns></returns>
		public override string ShowInfo()
		{
			string info;
			int result = Result();

			if (result > 0)
			{
				info = "Nieszczęście! W nocy, podczas warty twoich strażników, wataha dzików splądrowała twoje pole. Straciłeś " + result * 2 + " szt. chleba. Spadły morale";
			}
			else
			{
				info = " W nocy, podczas warty twoich strażników, wataha dzików zaczęła buszować w twoim polu pszenicy." +
						" Na szczęście Rycerze poradzili sobie z nimi. Tym samym zyskujesz " + -result + " szt. mięsa oraz morale!";
			}
			return info;
		}

		/// <summary>
		/// calculates invasion result
		/// </summary>
		/// <returns></returns>
		public int Result()
		{
			int numberOfBoars = Program.random.Next(10, 51);
			int boarsDefated = Program.player.hiredKnights * 4;
			int result = numberOfBoars - boarsDefated;

			if (result > 0)
			{
				int eatenBread = numberOfBoars * 2;

				if (Program.player.Bread >= eatenBread)
				{
					Program.player.Bread -= eatenBread;
				}
				else
				{
					Program.player.Bread = 0;
				}

				AdjustMorale(-1);
				return result;
			}
			else
			{
				int meatAdded = Program.player.hiredKnights;
				Program.player.Meat += meatAdded;
				AdjustMorale(1);
				return -meatAdded;
			}
		}
	}
}