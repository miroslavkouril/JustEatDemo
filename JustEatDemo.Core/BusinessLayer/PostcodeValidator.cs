using System;
using System.Text.RegularExpressions;

namespace JustEatDemo.Core.BL
{
	public class PostcodeValidator
	{
		// source: http://stackoverflow.com/questions/17012628/uk-postcode-regex
		private const string PostCodeRegex = "^[0-9A-Za-z ]{2,8}\\s*$";

		public bool IsValid(string postcode)
		{
			if (!string.IsNullOrEmpty(postcode))
			{
				var regex = new Regex(PostCodeRegex, RegexOptions.IgnoreCase);
				return regex.IsMatch(postcode);
			}
			else
			{
				return false;
			}
		}
	}
}

