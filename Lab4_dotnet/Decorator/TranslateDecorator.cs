using Lab4_dotnet.Component;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Lab4_dotnet.Decorator
{
	internal class TranslateDecorator : BaseDecorator
	{
		public TranslateDecorator(IComponent component) : base(component)
		{
		}

		public override void Write(string data)
		{
			string response = Translate(data, "en", "es");
			base.Write(response);
		}

		public override string Read()
		{
			string data = base.Read();

			string resultText = Translate(data, "es", "en");

			return resultText;

		}

		private static string Translate(string text, string from, string to)
		{
			var client = new RestClient("https://google-translate1.p.rapidapi.com");
			var request = new RestRequest("/language/translate/v2", Method.Post);
			request.AddHeader("content-type", "application/x-www-form-urlencoded");
			request.AddHeader("Accept-Encoding", "application/gzip");
			request.AddHeader("X-RapidAPI-Key", "d9548c47fcmsh13a4bee5b019aa1p11c7e9jsn6f3c19bc99c0");
			request.AddHeader("X-RapidAPI-Host", "google-translate1.p.rapidapi.com");
			request.AddParameter("application/x-www-form-urlencoded", $"q={text}&target={from}&source={to}", ParameterType.RequestBody);
			RestResponse response = client.Execute(request);

			JObject obj = JObject.Parse(response.Content!);
			JToken translation = obj["data"]?["translations"]?.FirstOrDefault()?["translatedText"]!;
			string decodedString = translation.ToString();

			Console.WriteLine(decodedString);
			return decodedString;

		}

	}
}
