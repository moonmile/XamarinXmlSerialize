// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace XamarinXmlSerialize.iOS
{
	[Register ("Xamarin_iOS_SingleViewViewController")]
	partial class Xamarin_iOS_SingleViewViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField textHighScore { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textModified { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textUserName { get; set; }

		[Action ("ClickLoad:")]
		partial void ClickLoad (MonoTouch.Foundation.NSObject sender);

		[Action ("ClickSave:")]
		partial void ClickSave (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (textUserName != null) {
				textUserName.Dispose ();
				textUserName = null;
			}

			if (textHighScore != null) {
				textHighScore.Dispose ();
				textHighScore = null;
			}

			if (textModified != null) {
				textModified.Dispose ();
				textModified = null;
			}
		}
	}
}
