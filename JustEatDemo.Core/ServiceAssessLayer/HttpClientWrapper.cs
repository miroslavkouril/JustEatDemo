using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JustEatDemo.Core
{
	public class HttpClientWrapper : IHttpClient
	{
		private readonly HttpClient client;

		public HttpClientWrapper(HttpClient client)
		{
			this.client = client;
		}

		public Task<HttpResponseMessage> GetAsync(string requestUri)
		{
			return client.GetAsync(requestUri);
		}

		public Task<byte[]> GetByteArrayAsync(string requestUri)
		{
			return client.GetByteArrayAsync(requestUri);
		}

		public Uri BaseAddress
		{
			get
			{
				return client.BaseAddress;
			}
			set
			{
				client.BaseAddress = value;
			}
		}

		public HttpRequestHeaders DefaultRequestHeaders
		{
			get
			{
				return client.DefaultRequestHeaders;
			}
		}

		public string GetStringFrom(string requestUri)
		{
			HttpResponseMessage response = client.GetAsync(requestUri).Result;
			return response.Content.ReadAsStringAsync().Result; 
		}

		public byte[] GetByteArrayFrom(string requestUri)
		{
			return client.GetByteArrayAsync(requestUri).Result;
		}
	}
}