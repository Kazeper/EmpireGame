using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Empire
{
	[Serializable()]
	public class Game : IGame
	{
		public int[] weekRequisition = new int[7];
		public int[] monthRequisition = new int[7];
		public List<Citizens> allCitizens;
		public List<Event> events;
		public double eventProb;
		public int indexOfKnights;

		public Game()
		{
			UpdateWeekRequisition();
			GenerateMonthRequisition();
			allCitizens = new List<Citizens>();
			AddCitizens();
			events = new List<Event>();
			AddEvents();
			eventProb = 0.35;
			indexOfKnights = 6;
		}

		/// <summary>
		/// Add citizens to list
		/// </summary>
		public void AddCitizens()
		{
			allCitizens.Add(new Citizens());
			allCitizens.Add(new Lumberjacks());
			allCitizens.Add(new Miners());
			allCitizens.Add(new Smiths());
			allCitizens.Add(new Farmers());
			allCitizens.Add(new Builders());
			allCitizens.Add(new Knights());
		}

		/// <summary>
		/// add all events to list
		/// </summary>
		public void AddEvents()
		{
			events.Add(new AfricanSwineFever());
			events.Add(new ArmyInvasion());
			events.Add(new BoarInvasion());
			events.Add(new Circus());
			events.Add(new GoldOre());
			events.Add(new HeavyRain());
			events.Add(new MineCollapse());
		}

		/// <summary>
		/// save game
		/// </summary>
		/// <returns></returns>
		public bool SaveGame()
		{
			bool result = false;
			//List<Object> objToSave = new List<object>();
			//objToSave.Add(this);
			//objToSave.Add(Program.player);

			FileStream fsGame = new FileStream("gameSave.dat", FileMode.Create);
			FileStream fsPlayer = new FileStream("playerSave.dat", FileMode.Create);
			BinaryFormatter formatter = new BinaryFormatter();

			try
			{
				formatter.Serialize(fsGame, this);
				formatter.Serialize(fsPlayer, Program.player);
				result = true;
			}
			catch (SerializationException e)
			{
				Console.WriteLine("Failed to serialize. Reason: " + e.Message);
				throw;
			}
			finally
			{
				fsGame.Close();
				fsPlayer.Close();
			}

			return result;
		}

		/// <summary>
		/// Load Game
		/// </summary>
		/// <returns></returns>
		public bool LoadGame()
		{
			bool result = false;
			List<Object> objToLoad = new List<object>();

			Stream fsGame = File.Open("gameSave.dat", FileMode.Open);
			Stream fsPlayer = File.Open("playerSave.dat", FileMode.Open);
			BinaryFormatter formatter = new BinaryFormatter();

			try
			{
				Program.game = (Game)formatter.Deserialize(fsGame);
				Program.player = (Player)formatter.Deserialize(fsPlayer);
				result = true;
			}
			catch (SerializationException e)
			{
				Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
				throw;
			}
			finally
			{
				fsPlayer.Close();
				fsGame.Close();
			}

			return result;
		}

		/// <summary>
		/// set and update week goals
		/// </summary>
		public void UpdateWeekRequisition()
		{
			weekRequisition[0] = Program.random.Next(3000, 5001); // requisition for gold
			weekRequisition[1] = Program.random.Next(1500, 1801); //requisition for wood
			weekRequisition[2] = Program.random.Next(1900, 2601); // requisition for ores
			weekRequisition[3] = Program.random.Next(Program.player.Population * 7, Program.player.Population * 8); //requisition for meat
			weekRequisition[4] = Program.random.Next(Program.player.Population * 8, Program.player.Population * 10); //requisition for bread
			weekRequisition[5] = Program.random.Next(2500, 3333); //requisition for nails
			weekRequisition[6] = Program.random.Next(50, 91); //requisition for tools
															  //TODO add += dla pozostalych tygodni
		}

		/// <summary>
		/// set month goal
		/// </summary>
		public void GenerateMonthRequisition()
		{
			for (int i = 0; i < weekRequisition.Length; i++)
			{
				monthRequisition[i] = (int)Math.Ceiling((weekRequisition[i] * 4.5));
			}
		}

		/// <summary>
		/// perform action according to previous day
		/// </summary>
		public void StartNewDay()
		{
			Program.player.NumberOfDays++;

			foreach (Citizens citizensGroup in allCitizens)
			{
				citizensGroup.PayTaxes();

				if (citizensGroup is IResourceProvider)
				{
					((IResourceProvider)citizensGroup).AddResources();
				}
				if (citizensGroup is IService)
				{
					if ((Program.player.NumberOfDays % 7) == 1)
					{
						((IService)citizensGroup).FinishService();
						if (Program.player.morale > 0)
						{
							Program.player.Population += Program.player.morale * 4;
						}
						else
						{
							Program.player.Population -= Program.player.morale * 3;
						}
					}

					((IService)citizensGroup).Hire();
				}

				citizensGroup.NumberOfMembers = 0;
			}

			PerformEventIfNeeded();
		}

		/// <summary>
		/// decide is event according to event probability
		/// </summary>
		/// <param name="eventProb"></param>
		/// <returns></returns>
		public bool IsEvent(double eventProb)
		{
			double number = Program.random.NextDouble();
			return number < eventProb;
		}

		/// <summary>
		/// perform event if needed
		/// </summary>
		public void PerformEventIfNeeded()
		{
			if (IsEvent(eventProb))
			{
				MessageBox.Show(events[Program.random.Next(0, events.Count)].ShowInfo());
			}
		}
	}
}