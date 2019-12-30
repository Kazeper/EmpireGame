using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	[Serializable()]
	public class Citizens
	{
		public int NumberOfMembers { get; set; }
		public int taxBase;
		public int minimalTaxBase;
		public int maximalTaxBase;

		public Citizens(int taxOffset = 0)
		{
			this.minimalTaxBase = 18;
			this.maximalTaxBase = 26;
			taxBase = Program.random.Next(minimalTaxBase, maximalTaxBase + 1) - taxOffset;
		}

		/// <summary>
		/// pays tax according to size of citizen group
		/// </summary>
		/// <param name="taxRate"></param>
		public virtual void PayTaxes(int taxRate = 1)
		{
			Program.player.Cash += this.NumberOfMembers * this.taxBase * taxRate;
		}
	}
}