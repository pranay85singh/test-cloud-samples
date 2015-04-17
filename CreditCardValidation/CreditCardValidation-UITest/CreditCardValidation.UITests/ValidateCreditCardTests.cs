using System;
using System.Linq;

using NUnit.Framework;

using Xamarin.UITest;
using Xamarin.UITest.Queries;
using UITests;

namespace CreditCardValidation.Tests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class ValidateCreditCardTests
	{
		/// <summary>
		///   This holds the AppQueries that will be used in the test.
		/// </summary>
		IScreenQueries _queries;
		IApp _app;
		Platform _platform;

		public ValidateCreditCardTests(Platform platform)
		{
			_platform = platform;	
		}

		[TestFixtureSetUp]
		public void TestFixtureSetup()
		{
			if(_platform.Equals(Platform.Android))
			{
				_queries = new AndroidQueries();
			} else if(_platform.Equals(Platform.iOS))
			{
				_queries = new iOSQueries();
			} else
			{
				throw new Exception("Could not initialize IScreenQueries");
			}
		}

		[SetUp]
		public void SetUp()
		{
			_app = AppInitializer.StartApp(_platform);
		}

		[Test]
		public void CreditCardNumber_CorrectSize_DisplaySuccessScreen()
		{

			/* Act */
			_app.EnterText(_queries.CreditCardNumberView, new string('9', 16));
			_app.Screenshot("Credit Card Number is correct length.");
			_app.Tap(_queries.ValidateButtonView);

			/* Assert */
			_app.WaitForElement(_queries.SuccessScreenNavBar, "Valid Credit Card screen did not appear", TimeSpan.FromSeconds(5));
			_app.Screenshot("Success screen for credit card number.");

			AppResult[] results = _app.Query(_queries.SuccessMessageView);
			Assert.IsTrue(results.Any(), "The success message was not displayed on the screen");
		}

		[Test]
		public void CreditCardNumber_IsBlank_DisplayErrorMessage(Platform platform)
		{

			/* Act */
			_app.EnterText(_queries.CreditCardNumberView, String.Empty);
			_app.Screenshot("Credit Card Number missing");
			_app.Tap(_queries.ValidateButtonView);

			/* Assert */
			AppResult[] result = _app.Query(_queries.MissingCreditCardNumberView);
			_app.Screenshot("Error message for a missing credit card number.");
			Assert.IsTrue(result.Any(), "The 'missing credit card' error message is not displayed.");
		}

		[Test]
		public void CreditCardNumber_TooLong_DisplayErrorMessage(Platform platform)
		{

			/* Act */
			_app.EnterText(_queries.CreditCardNumberView, new string('9', 17));
			_app.Screenshot("Credit Card Number is too long.");
			_app.Tap(_queries.ValidateButtonView);

			/* Assert */
			AppResult[] result = _app.Query(_queries.LongCreditCardNumberView);
			_app.Screenshot("Error message for long credit card nuymber.");
			Assert.IsTrue(result.Any(), "The 'long credit card' error message is not being displayed.");
		}

		[Test]
		public void CreditCardNumber_TooShort_DisplayErrorMessage(Platform platform)
		{
			/* Act */
			_app.EnterText(_queries.CreditCardNumberView, new string('9', 15));
			_app.Screenshot("Credit Card Number is too short.");
			_app.Tap(_queries.ValidateButtonView);

			/* Assert */
			AppResult[] result = _app.Query(_queries.ShortCreditCardNumberView);
			_app.Screenshot("Error message for short credit card number.");
			Assert.IsTrue(result.Any(), "The 'short credit card' error message is not being displayed.");
		}
	}
}
