using System;
using System.Threading;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace MobileDev.Android
{
    public static class Extension
    {
        public static void Initial(this IApp app)
        {
            if ((app.Query(x => x.Id("message"))).Length > 0)
            {
                app.Tap(x => x.Text("OK"));
            }
            else
            {
                app.Tap(x => x.Text("Yes"));
            }
            app.WaitForElement(x => x.Marked("cc_event_status_image"));
            app.Screenshot("General page loaded");

            app.Tap(x => x.Id("list_item_title"));
            app.WaitForElement(x => x.Text("Exhibitors"), timeout: TimeSpan.FromMinutes(2));
            app.Screenshot("Conference page loaded");

            Thread.Sleep(TimeSpan.FromSeconds(30));
            app.WaitForElement(x => x.Text("Exhibitors"), postTimeout: TimeSpan.FromSeconds(30));
            app.Screenshot("Home page loaded");
        }
    }
}

