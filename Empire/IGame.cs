using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire
{
	public interface IGame
	{
		bool SaveGame();

		bool LoadGame();
	}
}