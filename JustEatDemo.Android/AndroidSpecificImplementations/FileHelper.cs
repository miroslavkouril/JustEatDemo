using System;
using JustEatDemo.Core.DAL;
using System.IO;
using Java.IO;
using Android.Content;

namespace JustEatDemo
{
	public class FileHelper : IFileHelper
	{
		private readonly Context context;

		public FileHelper(Context context) : base()
		{
			this.context = context;
		}

		private string GetImageFileName(int fileId)
		{
			return string.Format("{0}.gif", fileId);
		}

		public string SaveImage(byte[] rawData, int fileId)
		{
			try
			{
				string fileName = GetImageFileName(fileId);

				var file = new Java.IO.File(context.FilesDir, fileName);
				if (file.Exists())
				{
					file.Delete();
				}

				var fos = context.OpenFileOutput(fileName, FileCreationMode.Private);
				fos.Write(rawData, 0, rawData.Length);
				fos.Close();

				return file.Path;
			}
			catch
			{
				return null;
			}
		}
	}
}

