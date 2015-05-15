using System;
using JustEatDemo.Core.BL.DataModels;

namespace JustEatDemo.Core.SAL
{
	public interface IWebService
	{
		ServiceResult DownloadDataFromWeb(string postcode);
		Byte[] DownloadImageFromWeb(string url);
	}
}