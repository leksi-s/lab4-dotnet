using Lab4_dotnet.Component;

namespace Lab4_dotnet.UserInteraction
{
	internal class Runner : IRunner
	{
		public void Run()
		{
			IComponent comp = new Base("C:\\Users\\Admin\\source\\repos\\Lab4_dotnet\\Lab4_dotnet\\data.txt");
			IMenu menu = new Menu(comp);

			Console.WriteLine("write a word:");
			string word = Console.ReadLine()!;
			comp.Write(word);
			string data = comp.Read();


			Dictionary<MenuItem, Action<string>> command = new Dictionary<MenuItem, Action<string>>()
			{
				{ MenuItem.Encrypt, menu.Encrypt},
				{ MenuItem.Decrypt, menu.Decrypt},
				{ MenuItem.Translate, menu.Translate},
				{ MenuItem.Retranslate, menu.Retranslate},
				{ MenuItem.Read, menu.Read}
			};
			string ans = "";
			while (!ans.ToLower().Contains("yes"))
			{
				Console.WriteLine("options: 1. encrypt \n 2. decrypt \n 3. translate \n 4. retranslate \n 5. read file \n Enter a number of option:");
				int num = int.Parse(Console.ReadLine());
				if (Enum.TryParse((num - 1).ToString(), out MenuItem queryType) && command.ContainsKey(queryType))
				{
					command[queryType](data);
				}
				else
				{
					Console.WriteLine("Invalid option number.");
				}
				Console.WriteLine("Do you wish to exit?");
				ans = Console.ReadLine();
			}


		}


		public enum MenuItem
		{
			Encrypt,
			Decrypt,
			Translate,
			Retranslate,
			Read
		}



	}
}

