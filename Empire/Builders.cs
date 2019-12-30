using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public class Builders : Citizens, IService
	{
		public Builders(int taxOffset = 0)
		{
			this.minimalTaxBase = 10;
			this.maximalTaxBase = 15;
			this.taxBase = Program.random.Next(this.minimalTaxBase, this.maximalTaxBase + 1) - taxOffset;
		}

		/// <summary>
		/// Hire builders for a week
		/// </summary>
		public void Hire()
		{
			Program.player.hiredBuilders += this.NumberOfMembers;
		}

		/// <summary>
		/// performs service - opens repairWall Form
		/// </summary>
		public void PerformService()
		{
			RepairWallForm repairWallForm = new RepairWallForm(Program.player.hiredBuilders);
			repairWallForm.ShowDialog();
		}

		/// <summary>
		/// update number of hired builders
		/// </summary>
		public void FinishService()
		{
			Program.player.hiredBuilders = 0;
		}
	}
}