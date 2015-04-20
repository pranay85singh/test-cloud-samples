using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using CreditCardValidation.Tests;

namespace CreditCardValidator.UITests
{
	public class AppInitializer
	{
		public static IScreenQueries Queries { get; set; }
		public static IApp StartApp(Platform platform)
		{
			if(platform == Platform.Android)
			{
				Queries = new AndroidQueries();
				return ConfigureApp.Android.StartApp();
			}

			Queries = new iOSQueries();
			return ConfigureApp.iOS.StartApp();
		}
	}
}

