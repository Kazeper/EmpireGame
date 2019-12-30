using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	internal class Smiths : Citizens, IResourceProvider
	{
		public int nailsFactor;
		public int toolsFactor;

		public Smiths(int taxOffset = 0)
		{
			this.minimalTaxBase = 5;
			this.maximalTaxBase = 10;
			this.taxBase = Program.random.Next(this.minimalTaxBase, this.maximalTaxBase + 1) - taxOffset;
			nailsFactor = 50;
			toolsFactor = 1;
		}

		/// <summary>
		/// generate resources
		/// </summary>
		public void AddResources()
		{
			Program.player.Nails += nailsFactor * this.NumberOfMembers;
			Program.player.Tools += toolsFactor * this.NumberOfMembers;
		}
	}
}