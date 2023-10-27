using Lab4_dotnet.Component;

namespace Lab4_dotnet.Decorator
{
	internal class BaseDecorator : IComponent
	{
		private readonly IComponent _component;
		public BaseDecorator(IComponent component)
		{
			_component = component;
		}
		public virtual string Read()
		{
			return _component.Read();
		}

		public virtual void Write(string data)
		{
			_component?.Write(data);
		}
	}
}
