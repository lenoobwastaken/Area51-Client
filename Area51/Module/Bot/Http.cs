using System.Collections.Specialized;
using System.Net;

namespace Area51.Module.Bot
{
	internal class Http
	{
		public static byte[] Post(string uri, NameValueCollection input)
		{
			using WebClient webClient = new WebClient();
			return webClient.UploadValues(uri, input);
		}
	}
}
