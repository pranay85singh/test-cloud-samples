using NUnit.Framework;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace MobileDev.Android
{
    [TestFixture()]
    public class SimpleTest
    {
        IApp app;

        [SetUp]
        public void Setup()
        {
            app = ConfigureApp
                .Android
                .ApkFile(Constants.ApkPath)
                .ApiKey(Constants.ApiKey)
                .StartApp();
        }

        [Test()]
        public void FindingUs()
        {
            app.Screenshot("App is open");
            app.Initial();

            app.Tap(x => x.Text("Exhibitors"));
            app.WaitForElement(x => x.Text("Exhibitors by Name"));
            app.Screenshot("Exhibitors search open");

            app.Tap(x => x.Text("Exhibitors by Name"));
            app.WaitForElement(x => x.Id("cc_event_guide_list_bookmark"));
            app.Screenshot("List of company names open");

            for (int i = 0; i < 2; i++)
            {
                app.ScrollDown();
                if ((app.Query(x => x.Marked("Xamarin"))).Length > 0)
                {
                    break;
                }
            }
            app.Screenshot("Scrolled thrice for the Xamarin name");


            app.Tap(x => x.Marked("Search"));
            app.EnterText(x => x.Id("search_bar"), "Xamarin");
            app.PressEnter();
            app.Screenshot("Searching for Xamarin with the search bar");

            app.Tap(x => x.Id("list_item_title").Text("Xamarin"));
            app.WaitForElement(x => x.Text("Xamarin"));
            app.Screenshot("Xamarin page");
        }
    }
}

