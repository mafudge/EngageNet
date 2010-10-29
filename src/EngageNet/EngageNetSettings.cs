using System.Net;

namespace EngageNet
{
	public class EngageNetSettings : IEngageNetSettings
	{
		private readonly string apiBaseUrl;
		private readonly string apiKey;
		private readonly IWebProxy webProxy;

		public EngageNetSettings(string apiKey)
			: this("https://rpxnow.com/api/v2/", apiKey, null)
		{
		}

		public EngageNetSettings(string apiBaseUrl, string apiKey, IWebProxy webProxy)
		{
			this.apiBaseUrl = apiBaseUrl;
			this.apiKey = apiKey;
			this.webProxy = webProxy;
		}

		#region IEngageNetSettings Members

		public IWebProxy WebProxy
		{
			get { return webProxy; }
		}

		public string ApiKey
		{
			get { return apiKey; }
		}

		public string ApiBaseUrl
		{
			get { return apiBaseUrl; }
		}

		#endregion
	}
}