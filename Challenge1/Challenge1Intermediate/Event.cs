namespace Challenge1Intermediate
{
	internal class Event
	{
		private static int _eventCounter;

		public int Id;
		public string Name;
		public int Hour;

		internal Event(string name, int hour)
		{
			_eventCounter++;
			Id = _eventCounter;
			Name = name;
			Hour = hour;
		}
	}
}
