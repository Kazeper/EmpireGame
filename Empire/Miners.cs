using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public class Miners : Citizens, IResourceProvider
	{
		public int oreFactor;

		public Miners(int taxOffset = 0)
		{
			this.minimalTaxBase = 8;
			this.maximalTaxBase = 14;
			this.taxBase = Program.random.Next(this.minimalTaxBase, this.maximalTaxBase + 1) - taxOffset;
			oreFactor = 30;
		}

		/// <summary>
		/// generate resources
		/// </summary>
		public void AddResources()
		{
			Program.player.Ore += oreFactor * this.NumberOfMembers;
		}
	}
}