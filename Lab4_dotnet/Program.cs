using Lab4_dotnet.UserInteraction;
class Program
{
	static void Main(string[] args)
	{
		IRunner runner = new Runner();
		runner.Run();
	}
}