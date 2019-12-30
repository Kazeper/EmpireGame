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
	public partial class IntroductionForm : Form
	{
		private EmpireForm empireForm;

		public IntroductionForm(EmpireForm empireForm)
		{
			InitializeComponent();
			this.empireForm = empireForm;
		}

		/// <summary>
		/// starts new game
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonSartNewGame_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// call Game.LoadGame
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonLoadGame_Click(object sender, EventArgs e)
		{
			bool result = empireForm.game.LoadGame();
			string info;

			if (result)
			{
				info = "gra została wczytana pomyślnie";
			}
			else
			{
				info = "nie udało się wczytać gry";
			}

			MessageBox.Show(info);
			this.Close();
		}
	}
}