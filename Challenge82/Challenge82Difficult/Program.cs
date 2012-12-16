using System;
using System.Linq;

namespace Challenge82Difficult
{
	class Program
	{
		private static readonly string[] Header = new[]
		{
			"| 1   | 2   | 3   | 4   | 5   | 6   | 7   | 8   | 9   | 10    |",
			"|-----|-----|-----|-----|-----|-----|-----|-----|-----|-------|",
			"|#####|#####|#####|#####|#####|#####|#####|#####|#####|#######|",
			"|+++++|+++++|+++++|+++++|+++++|+++++|+++++|+++++|+++++|+++++++|",
			"|_____|_____|_____|_____|_____|_____|_____|_____|_____|_______|",
			"|12345|67890|12345|67890|12345|67890|12345|67890|12345|6789012|",
			"|abcde|fghij|klmno|pqrst|uvwxy|zABCD|EFGHI|JKLMN|OPQRS|TUVWXYZ|"
		};

		private const string FrameFormat = "| {0} {1} ";
		private const string LastFrameFormat = "| {0} {1} {2} |";
		private const string ScoreFormat = "| {0,-4}";
		private const string LastScoreFormat = "| {0,-6}|";

		private static readonly Frame[] Frames = new Frame[10];

		static void Main(string[] args)
		{
			string input;
			do
			{
				Console.WriteLine("Input the bowling round data or \"stop\" to stop:");
				input = Console.ReadLine();
				if (input != "stop")
					CalculateScore(input);
			} while (input != "stop");
		}

		private static void CalculateScore(string input)
		{
			var parsed = input.Split(' ');
			var points = new int[parsed.Length];
			for (int i = 0; i < points.Length; i++)
				points[i] = int.Parse(parsed[i]);

			int point = 0;

			for (int frame = 0; frame < Frames.Length; frame++)
			{
				Frames[frame] = new Frame();

				var f = Frames[frame];

				f.First = points[point];
				f.FirstPointIndex = point;
				f.Score += f.First;

				if (f.First == 10) // Strike
				{
					f.Score += points[point + 1] + points[point + 2];
					point++;
				}
				else
				{
					f.Second = points[point + 1];

					f.Score += f.Second;

					if (f.First + f.Second == 10) // Spare
						f.Score += points[point + 2];

					point += 2;
				}

				if (frame > 0)
					f.Score += Frames[frame - 1].Score;

				if (frame == Frames.Length - 1)
				{
					if (points.Length >= f.FirstPointIndex)
					{
						f.Second = points[f.FirstPointIndex + 1];
						if (points.Length > f.FirstPointIndex)
							f.Third = points[f.FirstPointIndex + 2];
					}
				}
			}

			foreach (var s in Header)
				Console.WriteLine(s);

			for (int c = 0; c < 2; c++)
			{
				for (int i = 0; i < Frames.Length; i++)
				{
					if (c == 0)
					{
						if (i < Frames.Length - 1)
							Console.Write(FrameFormat, Frames[i].GetFirst(), Frames[i].GetSecond());
						else
							Console.WriteLine(LastFrameFormat, Frames[i].GetFirst(), Frames[i].GetSecond(), Frames[i].GetThird());
					}
					else
					{
						Console.Write(i < Frames.Length - 1 ? ScoreFormat : LastScoreFormat, Frames[i].Score);
					}
				}
			}

			Console.WriteLine("\nTotal: {0}", Frames.Last().Score);
		}
	}
}
