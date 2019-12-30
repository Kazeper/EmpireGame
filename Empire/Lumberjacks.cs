using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public class Lumberjacks : Citizens, IResourceProvider
	{
		public int woodFactor;

		public Lumberjacks(int taxOffset = 0)
		{
			this.minimalTaxBase = 2;
			this.maximalTaxBase = 8;
			this.taxBase = Program.random.Next(this.minimalTaxBase, this.maximalTaxBase + 1) - taxOffset;
			woodFactor = 20;
		}

		/// <summary>
		/// generate resources
		/// </summary>
		public void AddResources()
		{
			Program.player.Wood += this.NumberOfMembers * woodFactor;
		}
	}
}