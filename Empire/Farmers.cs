using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public class Farmers : Citizens, IResourceProvider
	{
		public int meatFactor;
		public int breadFactor;

		public Farmers(int taxOffset = 0)
		{
			this.minimalTaxBase = 4;
			this.maximalTaxBase = 11;
			this.taxBase = Program.random.Next(this.minimalTaxBase, this.maximalTaxBase + 1) - taxOffset;
			meatFactor = 3;
			breadFactor = 5;
		}

		/// <summary>
		/// generate resources
		/// </summary>
		public void AddResources()
		{
			Program.player.Meat += this.NumberOfMembers * meatFactor;
			Program.player.Bread += this.NumberOfMembers * breadFactor;
		}
	}
}