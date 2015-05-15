using JustEatDemo.Core.DAL;

namespace JustEatDemo.Core.Tests.DAL
{
	public class MockFileHelper : IFileHelper
	{
		public enum MockFileHelperBehaviour { 
			fhFileSaved,
			fhFailed
		};

		private MockFileHelperBehaviour mockFileHelperBehaviour;

		public string GetMockFilePath(int fileId)
		{
			return string.Format("/data/data/kouril.justeat.demo/files/{0}.gif", fileId);
		}

		public void SetMockServiceBehaviour(MockFileHelperBehaviour mockFileHelperBehaviour)
		{
			this.mockFileHelperBehaviour = mockFileHelperBehaviour;
		} 

		public string SaveImage(byte[] rawData, int fileId)
		{
			if (mockFileHelperBehaviour == MockFileHelperBehaviour.fhFileSaved)
			{
				if (rawData != null)
				{
					return GetMockFilePath(fileId);
				}
			}

			return null;
		}
	}
}