using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public class ArmyInvasion : Event, IInvasion
	{
		public int lostKnights;
		public int lostWallPoints;
		public bool isMoraleLost;
		public int indexOfKnights;

		public ArmyInvasion()
		{
			indexOfKnights = 6;
		}

		/// <summary>
		/// returns proper event info
		/// </summary>
		/// <returns></returns>
		public override string ShowInfo()
		{
			((Knights)Program.game.allCitizens[indexOfKnights]).PerformService();
			lostWallPoints = Result();
			Program.player.DefensiveWallPoints -= lostWallPoints;
			Program.player.hiredKnights -= lostKnights;
			string info = "w walce straciłeś " + lostKnights + " rycerzy oraz straciłeś " + lostWallPoints + " punktów muru.";

			if (isMoraleLost)
			{
				return info + " Spadły również morale";
			}
			else
			{
				return info + " Ale wygrałeś i wzrosły morale";
			}
		}

		/// <summary>
		/// calculate invasion result
		/// </summary>
		/// <returns></returns>
		public int Result()
		{
			lostKnights = 0;//init value
			lostWallPoints = 0;//init value

			int maxOpponents = ((int)((double)Program.player.hiredKnights * 1.5));
			int opponents;
			if (Program.player.hiredKnights < 5)
			{
				opponents = 10;
			}
			else
			{
				opponents = Program.random.Next(1, maxOpponents);
			}
			int opponentsAlive = opponents - Program.player.hiredKnights;

			int result = opponents * 5;

			if (opponentsAlive > 0)
			{
				result += opponentsAlive * 10;
				lostKnights = Program.player.hiredKnights;
				isMoraleLost = true;
				AdjustMorale(-1);
			}
			else
			{
				lostKnights = opponents - (int)(0.1 * Program.player.hiredKnights);
				isMoraleLost = false;
				AdjustMorale(1);
			}

			return result;
		}
	}
}