using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBox.Stuff
{
	class TournamentManager
	{
		#region Init

		public void Start(int participantsCount, int groupSize)
		{
			var groups = OctosplitAlliances(GenerateAlliancesCollectionIndexes(participantsCount), groupSize, new Random());

			foreach (var group in groups)
			{
				StartTournament(group);
			}
		}

		private void StartTournament(List<Alliance> alliances)
		{
			var r = new Random();
			var result = new Dictionary<int, RoundGrid>();

			for (int round = 1; round <= 3; round++)
			{
				var roundGrid = FormGrid(alliances);

				Console.WriteLine($@"Round {round}:");
				foreach (var p in roundGrid.Pairs)
				{
					p.AllianceOne.Points = r.Next(0, 1000);
					p.AllianceTwo.Points = r.Next(0, 1000);
					Console.WriteLine($@"Alliance {p.AllianceOne.Id} points: {p.AllianceOne.Points};" + "\n" +
					                  $@"Alliance {p.AllianceTwo.Id} points: {p.AllianceTwo.Points};" + "\n" +
					                  $@"Winner: {p.Winner.Id};" + "\n");
					p.Winner.ProgressStamp.Append('1');
					p.Loser.ProgressStamp.Append('0');
				}

				result.Add(round, roundGrid);
			}

			var finalStat = new StringBuilder("Tournament result: \n");
			foreach (var a in alliances)
			{
				finalStat.Append($@"Alliance: {a.Id}, ProgressStamp: {a.ProgressStamp}, Score: {a.TournamentScore}" + "\n");
			}

			Console.WriteLine(finalStat);
		}

		#endregion

		#region TournamentActorLogic

		private List<Alliance> GenerateAlliancesCollectionIndexes(int lim)
		{
			var result = new List<Alliance>();

			for (int i = 1; i <= lim; i++)
			{
				result.Add(new Alliance(i, new StringBuilder()));
			}

			return result;
		}

		private List<List<Alliance>> OctosplitAlliances(List<Alliance> allAlliances, int groupSize, Random r)
		{
			var result = new List<List<Alliance>>();
			if (allAlliances.Count % groupSize != 0)
			{
				return result;
			}

			var lim = allAlliances.Count / groupSize;

			for (int t = 0; t < lim; t++)
			{
				var group = new List<Alliance>();
				while (group.Count < groupSize)
				{
					var index = r.Next(0, allAlliances.Count);
					group.Add(allAlliances[index]);
					allAlliances.RemoveAt(index);
				}
				result.Add(group);
			}

			return result;
		}

		#endregion

		#region StageActorLogic

		private RoundGrid FormGrid(List<Alliance> alliances)
		{
			var stamps = alliances.Select(x => x.ProgressStamp.ToString()).Distinct().ToList();
			var result = new List<Pair>();

			foreach (var s in stamps)
			{
				var groups = alliances.Where(x => x.ProgressStamp.ToString().Equals(s)).ToList();
				result.AddRange(FormPairs(groups));
			}

			return new RoundGrid(result);
		}

		private List<Pair> FormPairs(List<Alliance> alliances)
		{
			var pairs = new List<Pair>();

			var lim = alliances.Count % 2 == 0 ? alliances.Count / 2 : alliances.Count / 2 + 1;
			for (int i = 0; i < lim; i++)
			{
				var allianceOne = alliances[i];
				var allianceTwo = i + lim >= alliances.Count ? null : alliances[i + lim];

				var pair = new Pair(allianceOne, allianceTwo);
				pairs.Add(pair);
			}

			var result = new StringBuilder("Tournament Grid:\n");
			foreach (var pair in pairs)
			{
				result.Append($@"{pair.AllianceOne.Id} versus {pair.AllianceTwo.Id}" + "\n");
			}

			Console.WriteLine(result);
			return pairs;
		}

		#endregion

		#region Entities

		private class RoundGrid
		{
			public readonly List<Pair> Pairs;

			public RoundGrid(List<Pair> pairs)
			{
				Pairs = pairs;
			}
		}

		private class Pair
		{
			public readonly Alliance AllianceOne;
			public readonly Alliance AllianceTwo;
			public Alliance Winner
				=> AllianceOne.Points >= AllianceTwo.Points ? AllianceOne : AllianceTwo;

			public Alliance Loser
				=> AllianceOne.Points >= AllianceTwo.Points ? AllianceTwo : AllianceOne;

			public Pair(Alliance allianceOne, Alliance allianceTwo)
			{
				AllianceOne = allianceOne;
				AllianceTwo = allianceTwo;
			}
		}

		private class Alliance
		{
			public readonly int Id;
			public int Points;
			public readonly StringBuilder ProgressStamp;

			public int TournamentScore =>
				ProgressStamp.ToString().Count(x => x != '0');

			public Alliance(int id, StringBuilder progressStamp)
			{
				Id = id;
				ProgressStamp = progressStamp;
			}
		}

		#endregion
	}
}
