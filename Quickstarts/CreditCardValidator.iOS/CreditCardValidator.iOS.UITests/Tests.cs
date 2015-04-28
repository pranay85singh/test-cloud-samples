using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace CreditCardValidator.iOS.UITests
{
	[TestFixture]
	public class Tests
	{
		iOSApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp.iOS.StartApp();
		}

		[Test]
		public void CreditCardNumber_TooShort_DisplayErrorMessage()
		{
			app.WaitForElement(c=>c.Class("UINavigationBar").Marked("Simple Credit Card Validator"));
			app.EnterText(c=>c.Class("UITextField"), new string('9', 15));
			app.Tap(c=>c.Marked("Validate Credit Card").Class("UIButton"));
			app.WaitForElement(c => c.Marked("Credit card number is too short.").Class("UILabel"));
		}
	}
}


