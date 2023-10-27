using Lab4_dotnet.Component;
using System.Security.Cryptography;
using System.Text;

namespace Lab4_dotnet.Decorator
{
	internal class DecryptionDecorator : BaseDecorator
	{
		public static RSAParameters PublicKey { get; set; }
		private static RSAParameters PrivateKey { get; set; }
		public DecryptionDecorator(IComponent component) : base(component)
		{
		}

		static DecryptionDecorator()
		{
			var keys = GenerateKeys();
			PublicKey = keys.publicKey;
			PrivateKey = keys.privateKey;
		}

		public override void Write(string data)
		{
			base.Write(Encrypt(data, PublicKey));
		}

		public override string Read()
		{
			string read = base.Read();
			return Decrypt(read, PrivateKey);
		}




		private static string Encrypt(string data, RSAParameters publicKey)
		{
			using var rsa = new RSACryptoServiceProvider();
			rsa.ImportParameters(publicKey);

			var initialBytes = Encoding.UTF8.GetBytes(data);
			var dataBase64 = Convert.ToBase64String(initialBytes);
			byte[] dataBytes = Convert.FromBase64String(dataBase64);
			var bytes = rsa.Encrypt(initialBytes, false);

			return Convert.ToBase64String(bytes);
		}
		private static string Decrypt(string data, RSAParameters privateKey)
		{
			using var rsa = new RSACryptoServiceProvider();
			rsa.ImportParameters(privateKey);

			byte[] dataBytes = Convert.FromBase64String(data);
			var bytes = rsa.Decrypt(dataBytes, false);

			return Encoding.UTF8.GetString(bytes);
		}

		public static (RSAParameters publicKey, RSAParameters privateKey) GenerateKeys()
		{
			using var rsa = new RSACryptoServiceProvider();
			RSAParameters privateKey = rsa.ExportParameters(true);
			RSAParameters publicKey = rsa.ExportParameters(false);

			return (publicKey, privateKey);
		}
	}
}
