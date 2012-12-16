using System.Globalization;

namespace Challenge82Difficult
{
	internal class Frame
	{
		public int Number;
		public int First;
		public int Second;
		public int Third;
		public int Score;

		public int FirstPointIndex;

		public string GetFirst()
		{
			return First == 10 ? "X" : (First == 0 ? "-" : First.ToString(CultureInfo.InvariantCulture));
		}

		public string GetSecond()
		{
			return First == 10 ? " " : (First + Second == 10 ? "/" : (Second == 0 ? "-" : Second.ToString(CultureInfo.InvariantCulture)));
		}

		public string GetThird()
		{
			return First + Second < 10 ? " " : (Third == 10 ? "X" : (Second + Third == 10 && First + Second < 10 ? "/" : (Third == 0 ? "-" : Third.ToString(CultureInfo.InvariantCulture))));
		}
	}
}
