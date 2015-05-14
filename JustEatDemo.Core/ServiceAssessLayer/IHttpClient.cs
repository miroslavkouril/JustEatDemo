using System;
using System.Net.Http;

namespace JustEatDemo.Core
{
	public interface IHttpClient
	{
		Uri BaseAddress { get; set; }
		System.Net.Http.Headers.HttpRequestHeaders DefaultRequestHeaders { get; }
		String GetStringFrom(string requestUri);
		Byte[] GetByteArrayFrom(string requestUri);
	}
}

