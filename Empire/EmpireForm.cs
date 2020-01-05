using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empire
{
	[Serializable()]
	public partial class EmpireForm : Form
	{
		public Game game;
		public List<CheckBox> weekCheckBox = new List<CheckBox>();
		private bool introHasBeenDisplayed;

		public readonly int indexOfOrdinaryCitizen;
		public readonly int indexOfLumberjacks;
		public readonly int indexOfMiners;
		public readonly int indexOfSmiths;
		public readonly int indexOfFarmers;
		public readonly int indexOfBuilders;
		public readonly int indexOfKnights;
		public int dayTime;

		public EmpireForm()
		{
			InitializeComponent();
			InitializeWeekCheckBox();
			//Program.player.empireForm = this;
			Program.game = new Game();
			game = Program.game;
			introHasBeenDisplayed = false;
			indexOfOrdinaryCitizen = 0;
			indexOfLumberjacks = 1;
			indexOfMiners = 2;
			indexOfSmiths = 3;
			indexOfFarmers = 4;
			indexOfBuilders = 5;
			indexOfKnights = 6;
			dayTime = 0;
		}

		/// <summary>
		/// add weekCheckBox to proper list
		/// </summary>
		public void InitializeWeekCheckBox()
		{
			weekCheckBox.Add(this.checkBoxWeek1);
			weekCheckBox.Add(this.checkBoxWeek2);
			weekCheckBox.Add(this.checkBoxWeek3);
			weekCheckBox.Add(this.checkBoxWeek4);
		}

		/// <summary>
		/// reset task per citizen
		/// </summary>
		public void ResetTasks()
		{
			game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers = Program.player.Population - Program.player.hiredKnights - Program.player.hiredBuilders;

			labelOrdinaryCitizens.Text = game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers.ToString();
			labelLumberjack.Text = game.allCitizens[indexOfLumberjacks].NumberOfMembers.ToString();
			labelMiner.Text = game.allCitizens[indexOfMiners].NumberOfMembers.ToString();
			labelSmith.Text = game.allCitizens[indexOfSmiths].NumberOfMembers.ToString();
			labelFarmer.Text = game.allCitizens[indexOfFarmers].NumberOfMembers.ToString();
			labelBuilder.Text = game.allCitizens[indexOfBuilders].NumberOfMembers.ToString();
			labelKnight.Text = game.allCitizens[indexOfKnights].NumberOfMembers.ToString();
			DisplayForecastedIncome<Object>(null);
		}

		/// <summary>
		/// set label text as resources
		/// </summary>
		public void DisplayPlayerResources()
		{
			labelCash.Text = Program.player.Cash.ToString();
			labelWood.Text = Program.player.Wood.ToString();
			labelOres.Text = Program.player.Ore.ToString();
			labelMeat.Text = Program.player.Meat.ToString();
			labelBread.Text = Program.player.Bread.ToString();
			labelNails.Text = Program.player.Nails.ToString();
			labelTools.Text = Program.player.Tools.ToString();
			labelOrdinaryCitizens.Text = game.allCitizens[0].NumberOfMembers.ToString();
			labelNumberOfBuilders.Text = Program.player.hiredBuilders.ToString();
			labelNumberOfKnights.Text = Program.player.hiredKnights.ToString();

			labelDay.Text = Program.player.NumberOfDays.ToString();
			double defensiveWall = Program.player.DefensiveWallPoints / 10;
			labelDefensiveWall.Text = defensiveWall.ToString() + "%";
			labelMoralePoints.Text = Program.player.morale.ToString();

			bool ableToRepair = (Program.player.hiredBuilders > 0) && (Program.player.DefensiveWallPoints < 1000);

			if (ableToRepair)
			{
				buttonRepairWall.Visible = true;
			}
		}

		/// <summary>
		/// display game goal
		/// </summary>
		public void DisplayRequisition()
		{
			labelGoldWeekRequisition.Text = game.weekRequisition[0].ToString();
			labelWoodWeekRequisition.Text = game.weekRequisition[1].ToString();
			labelOreWeekRequisition.Text = game.weekRequisition[2].ToString();
			labelMeatWeekRequisition.Text = game.weekRequisition[3].ToString();
			labelBreadWeekRequisition.Text = game.weekRequisition[4].ToString();
			labelNailsWeekRequisition.Text = game.weekRequisition[5].ToString();
			labelToolsWeekRequisition.Text = game.weekRequisition[6].ToString();

			labelGoldMonthRequisition.Text = game.monthRequisition[0].ToString();
			labelWoodMonthRequisition.Text = game.monthRequisition[1].ToString();
			labelOreMonthRequisition.Text = game.monthRequisition[2].ToString();
			labelMeatMonthRequisition.Text = game.monthRequisition[3].ToString();
			labelBreadMonthRequisition.Text = game.monthRequisition[4].ToString();
			labelNailsMonthRequisition.Text = game.monthRequisition[5].ToString();
			labelToolsMonthRequisition.Text = game.monthRequisition[6].ToString();
		}

		/// <summary>
		/// calculate nad set forecasted income as label's text
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="citizenGroup"></param>
		public void DisplayForecastedIncome<T>(T citizenGroup)
		{
			switch (citizenGroup)
			{
				case Lumberjacks group:
					labelWoodPerDay.Text = "+" + (group.NumberOfMembers * group.woodFactor).ToString();
					break;

				case Miners group:
					labelOrePerDay.Text = "+" + (group.NumberOfMembers * group.oreFactor).ToString();
					break;

				case Smiths group:
					labelNailsPerDay.Text = "+" + (group.NumberOfMembers * group.nailsFactor).ToString();
					labelToolsPerDay.Text = "+" + (group.NumberOfMembers * group.toolsFactor).ToString();
					break;

				case Farmers group:
					labelMeatPerDay.Text = "+" + (group.NumberOfMembers * group.meatFactor).ToString();
					labelBreadPerDay.Text = "+" + (group.NumberOfMembers * group.breadFactor).ToString();
					break;

				default:
					labelGoldPerDay.Text = "+";
					labelWoodPerDay.Text = "+";
					labelOrePerDay.Text = "+";
					labelNailsPerDay.Text = "+";
					labelToolsPerDay.Text = "+";
					labelMeatPerDay.Text = "+";
					labelBreadPerDay.Text = "+";
					break;
			}

			labelGoldPerDay.Text = MinimalGoldIncome().ToString();
		}

		/// <summary>
		/// calculate minimal gold income according to actual profession divide
		/// </summary>
		/// <returns></returns>
		public int MinimalGoldIncome()
		{
			int minimalGoldIncome = 0;

			foreach (Citizens citizens in game.allCitizens)
			{
				minimalGoldIncome += citizens.NumberOfMembers * citizens.minimalTaxBase;
			}

			return minimalGoldIncome;
		}

		/// <summary>
		/// display introduction Form
		/// </summary>
		public void DisplayIntroduction()
		{
			IntroductionForm introduction = new IntroductionForm(this);
			introduction.ShowDialog();
			//FightForm fightForm = new FightForm(5);//TODO ustawić introFORM <--- to tylko do testowania
			//fightForm.ShowDialog();
		}

		/// <summary>
		/// update citizen profession divide according to T param
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="citizenGroup"></param>
		/// <param name="toIncrease"></param>
		public void UpdateProfessionDivide<T>(T citizenGroup, bool toIncrease)
		{
			int numberOrdinaryCitizens = game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers;
			switch (citizenGroup)
			{
				case Lumberjacks group:
					if (toIncrease)
					{
						if (numberOrdinaryCitizens > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers--;
							((Lumberjacks)game.allCitizens[indexOfLumberjacks]).NumberOfMembers++;
						}
					}
					else
					{
						int numberOfMembers = ((Lumberjacks)game.allCitizens[indexOfLumberjacks]).NumberOfMembers;

						if (numberOfMembers > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers++;
							((Lumberjacks)game.allCitizens[indexOfLumberjacks]).NumberOfMembers--;
						}
					}

					labelLumberjack.Text = game.allCitizens[indexOfLumberjacks].NumberOfMembers.ToString();
					labelOrdinaryCitizens.Text = game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers.ToString();
					break;

				case Miners group:
					if (toIncrease)
					{
						if (numberOrdinaryCitizens > 0)
						{
							game.allCitizens[0].NumberOfMembers--;
							((Miners)game.allCitizens[indexOfMiners]).NumberOfMembers++;
						}
					}
					else
					{
						int numberOfMembers = ((Miners)game.allCitizens[indexOfMiners]).NumberOfMembers;

						if (numberOfMembers > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers++;
							((Miners)game.allCitizens[indexOfMiners]).NumberOfMembers--;
						}
					}

					labelMiner.Text = game.allCitizens[indexOfMiners].NumberOfMembers.ToString();
					labelOrdinaryCitizens.Text = game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers.ToString();
					break;

				case Smiths group:
					if (toIncrease)
					{
						if (numberOrdinaryCitizens > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers--;
							((Smiths)game.allCitizens[indexOfSmiths]).NumberOfMembers++;
						}
					}
					else
					{
						int numberOfMembers = ((Smiths)game.allCitizens[indexOfSmiths]).NumberOfMembers;

						if (numberOfMembers > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers++;
							((Smiths)game.allCitizens[indexOfSmiths]).NumberOfMembers--;
						}
					}

					labelSmith.Text = game.allCitizens[indexOfSmiths].NumberOfMembers.ToString();
					labelOrdinaryCitizens.Text = game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers.ToString();
					break;

				case Farmers group:
					if (toIncrease)
					{
						if (numberOrdinaryCitizens > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers--;
							((Farmers)game.allCitizens[indexOfFarmers]).NumberOfMembers++;
						}
					}
					else
					{
						int numberOfMembers = ((Farmers)game.allCitizens[indexOfFarmers]).NumberOfMembers;

						if (numberOfMembers > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers++;
							((Farmers)game.allCitizens[indexOfFarmers]).NumberOfMembers--;
						}
					}

					labelFarmer.Text = game.allCitizens[indexOfFarmers].NumberOfMembers.ToString();
					labelOrdinaryCitizens.Text = game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers.ToString();
					break;

				case Builders group:
					if (toIncrease)
					{
						if (numberOrdinaryCitizens > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers--;
							((Builders)game.allCitizens[indexOfBuilders]).NumberOfMembers++;
						}
					}
					else
					{
						int numberOfMembers = ((Builders)game.allCitizens[indexOfBuilders]).NumberOfMembers;

						if (numberOfMembers > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers++;
							((Builders)game.allCitizens[indexOfBuilders]).NumberOfMembers--;
						}
					}

					labelBuilder.Text = game.allCitizens[indexOfBuilders].NumberOfMembers.ToString();
					labelOrdinaryCitizens.Text = game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers.ToString();
					labelGoldPerDay.Text = MinimalGoldIncome().ToString();
					break;

				case Knights group:
					if (toIncrease)
					{
						if (numberOrdinaryCitizens > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers--;
							((Knights)game.allCitizens[indexOfKnights]).NumberOfMembers++;
						}
					}
					else
					{
						int numberOfMembers = ((Knights)game.allCitizens[indexOfKnights]).NumberOfMembers;

						if (numberOfMembers > 0)
						{
							game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers++;
							((Knights)game.allCitizens[indexOfKnights]).NumberOfMembers--;
						}
					}

					labelKnight.Text = game.allCitizens[indexOfKnights].NumberOfMembers.ToString();
					labelOrdinaryCitizens.Text = game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers.ToString();
					break;

				default:
					break;
			}
		}

		/// <summary>
		/// action on form load
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EmpireForm_Load(object sender, EventArgs e)
		{
			if (!introHasBeenDisplayed)
			{
				DisplayIntroduction();
				introHasBeenDisplayed = true;
			}

			game.allCitizens[indexOfOrdinaryCitizen].NumberOfMembers = Program.player.Population - Program.player.hiredKnights - Program.player.hiredBuilders;
			DisplayPlayerResources();
			DisplayRequisition();
			DisplayForecastedIncome<Object>(null);// Display starting forecasted Income = 0

			timerDay.Start();
		}

		/// <summary>
		/// set proper checkBox as checked
		/// </summary>
		/// <param name="numberOfDays"></param>
		public void CheckWeekCheckBox(int numberOfDays)
		{
			weekCheckBox[(int)Math.Floor((Convert.ToDouble(numberOfDays - 1)) / 7)].Checked = true;
			//TODO gdy konczy sie tydzeń zakonczyć grę
		}

		/// <summary>
		/// action according to increase number of lumberjacks
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonAddLumberjack_Click(object sender, EventArgs e)
		{
			bool toIncrease = true;
			UpdateProfessionDivide<Lumberjacks>((Lumberjacks)game.allCitizens[1], toIncrease);
			DisplayForecastedIncome<Lumberjacks>((Lumberjacks)game.allCitizens[1]);
		}

		/// <summary>
		/// action according to increase number of miners
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonAddMiner_Click(object sender, EventArgs e)
		{
			bool toIncrease = true;
			UpdateProfessionDivide<Miners>((Miners)game.allCitizens[2], toIncrease);
			DisplayForecastedIncome<Miners>((Miners)game.allCitizens[2]);
		}

		/// <summary>
		/// action according to increase number of smiths
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonAddSmith_Click(object sender, EventArgs e)
		{
			bool toIncrease = true;
			UpdateProfessionDivide<Smiths>((Smiths)game.allCitizens[3], toIncrease);
			DisplayForecastedIncome<Smiths>((Smiths)game.allCitizens[3]);
		}

		/// <summary>
		/// action according to increase number of farmers
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonAddFarmer_Click(object sender, EventArgs e)
		{
			bool toIncrease = true;
			UpdateProfessionDivide<Farmers>((Farmers)game.allCitizens[4], toIncrease);
			DisplayForecastedIncome<Farmers>((Farmers)game.allCitizens[4]);
		}

		/// <summary>
		/// action according to increase number of builders
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonAddBuilder_Click(object sender, EventArgs e)
		{
			bool toIncrease = true;
			UpdateProfessionDivide<Builders>((Builders)game.allCitizens[5], toIncrease);
		}

		/// <summary>
		/// action according to increase number of knights
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonAddKnight_Click(object sender, EventArgs e)
		{
			bool toIncrease = true;
			UpdateProfessionDivide<Knights>((Knights)game.allCitizens[6], toIncrease);
		}

		/// <summary>
		/// action according to decrease number of lumberjacks
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRemoveLumberjack_Click(object sender, EventArgs e)
		{
			bool toIncrease = false;
			UpdateProfessionDivide<Lumberjacks>((Lumberjacks)game.allCitizens[1], toIncrease);
			DisplayForecastedIncome<Lumberjacks>((Lumberjacks)game.allCitizens[1]);
		}

		/// <summary>
		/// action according to decrease number of miners
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRemoveMiner_Click(object sender, EventArgs e)
		{
			bool toIncrease = false;
			UpdateProfessionDivide<Miners>((Miners)game.allCitizens[2], toIncrease);
			DisplayForecastedIncome<Miners>((Miners)game.allCitizens[2]);
		}

		/// <summary>
		/// action according to decrease number of smiths
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRemoveSmith_Click(object sender, EventArgs e)
		{
			bool toIncrease = false;
			UpdateProfessionDivide<Smiths>((Smiths)game.allCitizens[3], toIncrease);
			DisplayForecastedIncome<Smiths>((Smiths)game.allCitizens[3]);
		}

		/// <summary>
		/// action according to decrease number of farmers
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRemoveFarmer_Click(object sender, EventArgs e)
		{
			bool toIncrease = false;
			UpdateProfessionDivide<Farmers>((Farmers)game.allCitizens[4], toIncrease);
			DisplayForecastedIncome<Farmers>((Farmers)game.allCitizens[4]);
		}

		/// <summary>
		/// action according to decrease number of builders
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRemoveBuilder_Click(object sender, EventArgs e)
		{
			bool toIncrease = false;
			UpdateProfessionDivide<Builders>((Builders)game.allCitizens[5], toIncrease);
		}

		/// <summary>
		/// action according to decrease number of knights
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRemoveKnight_Click(object sender, EventArgs e)
		{
			bool toIncrease = false;
			UpdateProfessionDivide<Knights>((Knights)game.allCitizens[6], toIncrease);
		}

		/// <summary>
		/// show lumberjacks details
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBoxLumberjack_MouseHover(object sender, EventArgs e)
		{
			toolTipLumberjack.Show("określ ile osób ma pracować jako drwal", pictureBoxLumberjack);
		}

		/// <summary>
		/// show miners details
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBoxMiner_MouseHover(object sender, EventArgs e)
		{
			toolTipMiner.Show("określ ile osób ma pracować jako górnik", pictureBoxMiner);
		}

		/// <summary>
		/// show smiths details
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBoxSmith_MouseHover(object sender, EventArgs e)
		{
			toolTipSmith.Show("określ ile osób ma pracować jako kowal", pictureBoxSmith);
		}

		/// <summary>
		/// show farmers details
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBoxFarmer_MouseHover(object sender, EventArgs e)
		{
			toolTipFarmer.Show("Określ ile osób ma pracować jako rolnik", pictureBoxFarmer);
		}

		/// <summary>
		/// show builders details
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBoxBuilder_MouseHover(object sender, EventArgs e)
		{
			toolTipBuilder.Show("określ ile osób ma pracować jako budowniczy. Budowniczych zatrudniasz na cały tydzień", pictureBoxBuilder);
		}

		/// <summary>
		/// show knights details
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBoxKnight_MouseHover(object sender, EventArgs e)
		{
			string knightMessage = "Określ ile osób ma walczyć w obronie Królestwa. Rycerzy zatrudniasz na tydzień. Są oni zwolnieni z płacenia podatków";
			toolTipKnight.Show(knightMessage, pictureBoxKnight);
		}

		/// <summary>
		/// ends actual day
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonNextDay_Click(object sender, EventArgs e)
		{
			game.StartNewDay();
			dayTime = 0;
			ResetTasks();
			DisplayPlayerResources();
			DisplayRequisition();
			CheckWeekCheckBox(Program.player.NumberOfDays);
			timerDay.Start();
		}

		/// <summary>
		/// seconds counter, ends actual day
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timerMain_Tick(object sender, EventArgs e)
		{
			dayTime++;
			labelDayTime.Text = dayTime.ToString();
			if (dayTime == 60)
			{
				timerDay.Stop();
				this.buttonNextDay_Click(sender, e);
			}
		}

		/// <summary>
		/// perform repairing wall service
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRepairWall_Click(object sender, EventArgs e)
		{
			timerDay.Stop();
			((Builders)game.allCitizens[indexOfBuilders]).PerformService();
			buttonRepairWall.Visible = false;
			timerDay.Start();
		}

		/// <summary>
		/// save game on clik
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonSaveGame_Click(object sender, EventArgs e)
		{
			if (game.SaveGame())
			{
				MessageBox.Show("Grę zapisano pomyślnie");
			}
			else MessageBox.Show("nie udało się zapisać gry");
		}
	}
}