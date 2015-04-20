using System;
		
using UIKit;
using CreditCardValidation.Common;

namespace CreditCardValidator.iOS
{
	public partial class ViewController : UIViewController
	{
		static readonly ICreditCardValidator _validator = new SimpleCreditCardValidator();

		public ViewController(IntPtr handle) : base(handle)
		{		
		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			CreditCardTextField.BackgroundColor = UIColor.White;;
			CreditCardTextField.Layer.BorderColor = UIColor.Clear.CGColor;
			CreditCardTextField.Layer.BorderWidth = 0;
			CreditCardTextField.Layer.CornerRadius = 0;
			ErrorMessagesTextField.Text = String.Empty;					

		}
		public override void DidReceiveMemoryWarning()
		{		
			base.DidReceiveMemoryWarning();		
			// Release any cached data, images, etc that aren't in use.		
		}

		partial void ValidateButton_TouchUpInside(UIButton sender)
		{
			ErrorMessagesTextField.Text = String.Empty;
			string errorMessage;
			bool isValid = _validator.IsCCValid(CreditCardTextField.Text, out errorMessage);


			if(isValid)
			{
				UIViewController ctlr = this.Storyboard.InstantiateViewController("ValidCreditCardController");
				NavigationController.PushViewController(ctlr, true);
			} else
			{
				InvokeOnMainThread(() => {
					CreditCardTextField.BackgroundColor = UIColor.Yellow;
					CreditCardTextField.Layer.BorderColor = UIColor.Red.CGColor;
					CreditCardTextField.Layer.BorderWidth = 3;
					CreditCardTextField.Layer.CornerRadius = 5;
					ErrorMessagesTextField.Text = errorMessage;					
				});
			}
		}
	}
}
