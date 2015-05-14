using System;
using NUnit.Framework;
using JustEatDemo.Core.BL;

namespace JustEatDemo.Core.Tests.BL
{
	[TestFixture()]
	public class PostCodeValidatorTest
	{
		private readonly string[] ValidPostcodes = { 
			"BR3 3HJ", "br3 3hj", "bR3 3hJ", 
			"BR33HJ", "br33hj", "bR33hJ",
			"EC1A 1BB", "W1A 0AX", "M1 1AE", "B33 8TH", "CR2 6XH", "DN55 1PT",
			"EC1A1BB", "W1A0AX", "M11AE", "B338TH", "CR26XH", "DN551PT"
		};

		private readonly string[] InvalidPostcodes = { 
			null, string.Empty, "a", "a1a1a1a1a1a", "234342556"
		};


		private PostcodeValidator validator;

		[SetUp]
		public void SetUp()
		{
			validator = new PostcodeValidator();
		}

		[Test]
		public void InitializationComplete()
		{
			Assert.IsNotNull(validator);
		}

		[Test]
		public void IsValidTest()
		{
			foreach (var postcode in ValidPostcodes)
			{
				Assert.IsTrue(validator.IsValid(postcode));
			}

			foreach (var postcode in InvalidPostcodes)
			{
				Assert.IsFalse(validator.IsValid(postcode));
			}
		}
	}
}

