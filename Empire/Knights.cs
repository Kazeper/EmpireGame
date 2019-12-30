using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empire
{
	[Serializable()]
	public class Knights : Citizens, IService
	{
		/// <summary>
		/// hire knights for a week
		/// </summary>
		public void Hire()
		{
			Program.player.hiredKnights += this.NumberOfMembers;
		}

		/// <summary>
		/// decrease food resources due to hungry
		/// </summary>
		public void Eat()
		{
			bool isEnough = Program.player.Bread >= 3 && Program.player.Meat >= 2;
			if (isEnough)
			{
				Program.player.Bread -= 3;
				Program.player.Meat -= 2;
			}
			else
			{
				Program.player.Bread = 0;
				Program.player.Meat = 0;
			}
		}

		/// <summary>
		/// pays tax according to size of citizen group
		/// </summary>
		/// <param name="taxRate"></param>
		public override void PayTaxes(int taxRate = 1)
		{
			//knights doesnt pay taxes
		}

		public void PerformService()
		{
			int numberOfKnights = Program.player.hiredKnights;
			if (numberOfKnights != 0)
			{
				FightForm fightForm = new FightForm();
				fightForm.ShowDialog();
			}
		}

		public void FinishService()
		{
			Program.player.hiredKnights = 0;
		}
	}
}