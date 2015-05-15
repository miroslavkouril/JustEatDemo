using System.Collections.Generic;
using Newtonsoft.Json;

namespace JustEatDemo.Core.BL
{
	public static class SaveInstanceStateHelper
	{
		public static string StructureAsJSONString<T>(T structure)
		{
			if (structure == null)
			{
				return null;
			}

			return JsonConvert.SerializeObject(structure);
		}

		public static T StructureFromJSONString<T>(string jsonString)
		{
			if (jsonString == null)
			{
				return default(T);
			}

			try
			{
				return JsonConvert.DeserializeObject<T>(jsonString);
			}
			catch
			{
				return default(T);
			}
		}

		public static string[] StructureListAsJSONString<T>(List<T> structureList)
		{
			if ((structureList == null) || (structureList.Count == 0))
			{
				return null;
			}

			string[] jsonString = new string[structureList.Count];

			for (int i = 0; i < structureList.Count; i++)
			{
				jsonString[i] = JsonConvert.SerializeObject(structureList[i]);
			}

			return jsonString;
		}

		public static List<T> StructureListFromJSONString<T>(string[] jsonString)
		{
			if (jsonString == null)
			{
				return null;
			}

			try
			{
				List<T> list = new List<T>();

				for (int i = 0; i < jsonString.Length; i++)
				{
					list.Add(JsonConvert.DeserializeObject<T>(jsonString[i]));
				}

				return list;
			}
			catch
			{
				return null;
			}
		}
	}
}