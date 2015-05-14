using System;

namespace JustEatDemo.Core.DAL
{
	public interface IFileHelper
	{
		string SaveImage(byte[] rawData, int fileId);
	}
}

