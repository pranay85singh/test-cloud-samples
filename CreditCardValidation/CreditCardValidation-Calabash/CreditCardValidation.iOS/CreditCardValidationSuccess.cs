using CoreGraphics;

using UIKit;

namespace CreditCardValidation.iOS
{
    public class CreditCardValidationSuccess : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            Title = "Valid Credit Card";

            UILabel successLabel = new UILabel(new CGRect(10, 165, 300, 40))
                                   {
                                       AccessibilityIdentifier =  "CreditCardIsValidLabel",
                                       Text = "The credit card number is valid!", 
                                       TextAlignment = UITextAlignment.Center
                                   };

            View.Add(successLabel);
        }
    }
}
