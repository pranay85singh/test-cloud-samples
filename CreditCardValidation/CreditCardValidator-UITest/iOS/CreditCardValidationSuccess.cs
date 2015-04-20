using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CreditCardValidator.iOS
{
	partial class CreditCardValidationSuccess : UIViewController
	{
		public CreditCardValidationSuccess (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			#if ENABLE_TEST_CLOUD
			CreditCardIsValidLabel.AccessibilityIdentifier = "CreditCardIsValidLabel";
			#endif
		}
	}
}
