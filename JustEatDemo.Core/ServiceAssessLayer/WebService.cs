using System.Net.Http;
using System;
using Newtonsoft.Json;
using JustEatDemo.Core.BL.DataModels;
using System.Net;

namespace JustEatDemo.Core.SAL
{
	public class WebService : IWebService
	{
		private readonly IHttpClient httpClient;

		public WebService()
		{
			httpClient = new HttpClientWrapper(new HttpClient());
		}

		public WebService(IHttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public ServiceResult DownloadDataFromWeb(string postcode)
		{
			try
			{
				httpClient.BaseAddress = new Uri("http://api-interview.just-eat.com/restaurants");
				httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "VGVjaFRlc3RBUEk6dXNlcjI=");
				httpClient.DefaultRequestHeaders.Host = "api-interview.just-eat.com";
				httpClient.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
				httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-GB");

				var data = httpClient.GetStringFrom(string.Format("?q={0}", postcode));
				if (data != null)
				{
					return JsonConvert.DeserializeObject<ServiceResult>(data);
				}
				else
				{
					return new ServiceResult();
				}
			}
			catch (Exception ex)
			{
				string mesas = ex.Message;
				return new ServiceResult();
			}
					
		}

		public Byte[] DownloadImageFromWeb(string url)
		{
			try
			{
				return httpClient.GetByteArrayFrom(url); 
			}
			catch 
			{
				return null;
			}
		}
	}
}

