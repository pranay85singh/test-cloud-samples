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
			

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			ErrorMessagesTextField.Text = string.Empty;
			CreditCardTextField.Text = string.Empty;

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
						ErrorMessagesTextField.Text = errorMessage;					
					});
			}
		}
	}
}

