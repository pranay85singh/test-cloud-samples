using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace BackdoorActivity.UITests
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .Android
                .StartApp();
        }

        [Test]
        public void Click_button_for_second_activity()
        {
            // Arrange
            app.WaitForElement(c => c.Marked("button1"));
            app.Tap(c => c.Button("button1"));

            // Act 
            EnterTextOnActivityTwo("Text #1");

            // Assert
            AssertTextHasBeenEnteredOnSecondActivity("Text #1");
        }

        [Test]
        public void Use_backdoor_for_second_activity()
        {
            // Arrange
            app.WaitForElement(c => c.Marked("button1"));
            app.Invoke("StartActivityTwo");

            // Act 
            EnterTextOnActivityTwo("Text #2");

            //Assert
            AssertTextHasBeenEnteredOnSecondActivity("Text #2");
        }

        void EnterTextOnActivityTwo(string text)
        {
            app.WaitForElement(c => c.Marked("editText2"));
            app.EnterText(c => c.TextField("editText2"), text);
            app.DismissKeyboard();
        }

        void AssertTextHasBeenEnteredOnSecondActivity(string textThatShouldBeEntered)
        {
            object[] queryResults = app.Query(c => c.Marked("editText2").Invoke("getText"));
            if (queryResults.Any())
            {
                string textThatWasEntered = queryResults[0].ToString();
                Assert.AreEqual(textThatShouldBeEntered, textThatWasEntered);
            }
            else
            {
                Assert.Inconclusive("Could not determine if the EditText has the string " + textThatShouldBeEntered + ".");
            }
        }
    }
}