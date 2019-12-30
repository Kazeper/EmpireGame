using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empire
{
	[Serializable()]
	public class Player
	{
		//public EmpireForm empireForm;
		public int Cash { get; set; }

		public int Wood { get; set; }
		public int Ore { get; set; }
		public int Meat { get; set; }
		public int Bread { get; set; }
		public int Nails { get; set; }
		public int Tools { get; set; }
		public int NumberOfDays { get; set; }
		public int Population { get; set; }
		public int morale;
		public int hiredBuilders;
		public int hiredKnights;
		public int DefensiveWallPoints { get; set; }

		//public int ordinaryCitizens;
		//public int lumberjacksCounter;
		//public int minersCounter;
		//public int shmitsCounter;
		//public int farmersCounter;
		//public int buildersCounter;
		//public int knightsCounter;

		public Player()
		{
			Cash = 5;
			Wood = 0;
			Ore = 0;
			Meat = 2;
			Bread = 3;
			Nails = 10;
			Tools = 5;
			morale = 0;
			NumberOfDays = 1;
			Population = 50;
			DefensiveWallPoints = 1000;

			//ordinaryCitizens = Population;
		}

		//public void DisplayPlayerResources()
		//{
		//	(empireForm.labelCash.Text = Program.player.Cash.ToString();
		//	((EmpireForm)Application.OpenForms[0]).labelWood.Text = Program.player.Wood.ToString();
		//	((EmpireForm)Application.OpenForms[0]).labelOres.Text = Program.player.Ore.ToString();
		//	((EmpireForm)Application.OpenForms[0]).labelMeat.Text = Program.player.Meat.ToString();
		//	((EmpireForm)Application.OpenForms[0]).labelBread.Text = Program.player.Bread.ToString();
		//	((EmpireForm)Application.OpenForms[0]).labelNails.Text = Program.player.Nails.ToString();
		//	((EmpireForm)Application.OpenForms[0]).labelTools.Text = Program.player.Tools.ToString();
		//	string ordinaryCitizenLabel = ((EmpireForm)Application.OpenForms[0]).game.allCitizens[0].NumberOfMembers.ToString();
		//	((EmpireForm)Application.OpenForms[0]).labelOrdinaryCitizens.Text = ordinaryCitizenLabel;

		//	((EmpireForm)Application.OpenForms[0]).labelNumberOfBuilders.Text = ((EmpireForm)Application.OpenForms[0]).game.hiredKnights.ToString();
		//}
	}
}