namespace Lab4_dotnet.UserInteraction
{
	internal interface IMenu
	{
		void Translate(string data);
		void Retranslate(string data);
		void Encrypt(string data);
		void Decrypt(string data);
		void Read(string data);
	}
}
