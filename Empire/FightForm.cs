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
	public partial class FightForm : Form
	{
		private int counter;
		private Point point;

		public FightForm()
		{
			InitializeComponent();
			counter = 0;
			MessageBox.Show("Twoje królestwo zostało zaatakowane!" + Environment.NewLine + " Broń się!    (klikaj w przeciwnika :))");
			point = new Point();
			point.Y = 21;
			timerMain.Interval = Program.player.hiredKnights * 1500;
			timerMain.Start();
			timerEnemyPosition.Start();
		}

		/// <summary>
		/// generate location for enemy
		/// </summary>
		/// <returns></returns>
		public Point GenerateNextLocation()
		{
			point.X = Program.random.Next(20, 711);
			return point;
		}

		/// <summary>
		/// change position on timer tick
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timerEnemyPosition_Tick(object sender, EventArgs e)
		{
			pictureBoxEnemy.Location = GenerateNextLocation();
			labelCounter.Text = counter.ToString();
		}

		private void timerMain_Tick(object sender, EventArgs e)
		{
			timerEnemyPosition.Stop();
			timerMain.Stop();
			pictureBoxFight.Visible = true;
			pictureBoxEnemy.Visible = false;
			labelCounter.Visible = false;
			labelCounterInfo.Visible = false;
			timerShowFight.Start();
		}

		/// <summary>
		/// counts number of picture clicks
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBoxEnemy_Click(object sender, EventArgs e)
		{
			counter++;
		}

		/// <summary>
		/// display battle stats
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timerShowFight_Tick(object sender, EventArgs e)
		{
			timerShowFight.Stop();
			MessageBox.Show("Trafiono " + counter + " bandytów");
			this.Close();
		}
	}
}