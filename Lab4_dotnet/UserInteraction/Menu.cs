using Lab4_dotnet.Component;
using Lab4_dotnet.Decorator;

namespace Lab4_dotnet.UserInteraction
{
	internal class Menu : IMenu
	{
		private IComponent _component;

		public Menu(IComponent component)
		{
			_component = component;
		}
		public void Decrypt(string data)
		{
			var decorator = new DecryptionDecorator(_component);
			Console.WriteLine(decorator.Read());
		}

		public void Encrypt(string data)
		{
			var decorator = new DecryptionDecorator(_component);
			decorator.Write(data);
			Console.WriteLine("text was encrypted");
		}

		public void Read(string data)
		{
			Console.WriteLine(_component.Read());
		}

		public void Retranslate(string data)
		{
			var decorator = new TranslateDecorator(_component);
			Console.WriteLine(decorator.Read());
		}

		public void Translate(string data)
		{
			var decorator = new TranslateDecorator(_component);
			decorator.Write(data);
			Console.WriteLine("text was translated");
		}
	}
}
