namespace Lab4_dotnet.Component
{
	internal class Base : IComponent
	{
		private readonly string _path;
		public Base(string path)
		{
			_path = path;
		}
		public string Read()
		{
			using StreamReader reader = new(_path);
			return reader.ReadToEnd();
		}

		public void Write(string data)
		{
			using StreamWriter writer = new(_path);
			writer.Write(data);
		}
	}
}
