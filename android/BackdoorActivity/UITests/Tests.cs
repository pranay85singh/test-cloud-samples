using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace BackdoorActivity.UITests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                //.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
                .StartApp();
        }

        AndroidApp app;

        [Test]
        public void Click_button_for_second_activity()
        {
            app.WaitForElement(c => c.Marked("button1"));
            app.Tap(c => c.Button("button1"));

            app.WaitForElement(c => c.Marked("editText2"));
            app.EnterText(c => c.TextField("editText2"), "Some text.");
            app.DismissKeyboard();
        }

        [Test]
        public void Start_activity_two()
        {
            app.WaitForElement(c => c.Marked("button1"));
            app.Invoke("StartActivityTwo:");

            app.WaitForElement(c => c.Marked("editText2"));
            app.EnterText(c => c.TextField("editText2"), "Some text that different.");
            app.DismissKeyboard();
        }
    }
}