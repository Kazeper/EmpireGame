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
	public partial class RepairWallForm : Form
	{
		public int counter;

		public RepairWallForm(int numberOfBuilders)
		{
			counter = 0;
			InitializeComponent();
			MessageBox.Show("Aby naprawić mur musisz zebrać jak najwięcej cegieł" + Environment.NewLine + "Im więcej budowniczych, tym więcej czasu na zbieranie");
			timerMain.Interval = numberOfBuilders * 2000;
			timerMain.Start();
			timerBrickPosition.Start();
		}

		/// <summary>
		/// generate brick position
		/// </summary>
		/// <returns></returns>
		public Point GenerateNextLocation()
		{
			Point point = new Point();
			point.X = Program.random.Next(145, 723);
			point.Y = Program.random.Next(83, 505);

			return point;
		}

		/// <summary>
		/// change position when tick
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timerBrickPosition_Tick(object sender, EventArgs e)
		{
			pictureBoxBrick.Location = GenerateNextLocation();
			labelCounter.Text = counter.ToString();
		}

		/// <summary>
		/// game is over when tick
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timerMain_Tick(object sender, EventArgs e)
		{
			timerBrickPosition.Stop();
			timerMain.Stop();
			Program.player.DefensiveWallPoints += counter * 4;

			MessageBox.Show("odbudowano " + counter * 10 + " punktów muru obronnego");
			this.Close();
		}

		/// <summary>
		/// action when brick is clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBoxBrick_Click(object sender, EventArgs e)
		{
			counter++;
		}
	}
}