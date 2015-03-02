using NUnit.Framework;
using Xamarin.UITest;

namespace AndroidQuickstart
{
	[TestFixture]
	public class AndroidQuickstart
	{
		private IApp app;
		private const string pathToBinary = "com.xamarin.XamStore.apk";

		[SetUp]
		public void Setup()
		{
			app = ConfigureApp
				.Android
				.ApkFile (pathToBinary)
				.ApiKey (ApiKey.Key) // Go into ApiKey.cs to add your api key for Xamarin Test Cloud
				.StartApp ();
		}	

		[TestCase(TestName="Verify the app launches")]
		public void BasicTest ()
		{
			// Arrange
			var elements = app.WaitForElement (e => e.All (), "Nothing has loaded on the screen.");

			// Act
			app.Screenshot ("First screen of the app");

			// Assert
			Assert.IsTrue (elements.Length > 0);
		}
	}
}

