namespace Challenge1Intermediate
{
	internal delegate void CallbackDelegate();

	internal class MenuItem
	{
		internal string Name { get; private set; }
		internal CallbackDelegate Callback { get; private set; }

		internal MenuItem(string name, CallbackDelegate callback)
		{
			Name = name;
			Callback = callback;
		}
	}
}
