// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SampleNotificationExtension
{
	[Register ("NotificationViewController")]
	partial class NotificationViewController
	{
		[Outlet]
		UIKit.UIImageView MyImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MyImageView != null) {
				MyImageView.Dispose ();
				MyImageView = null;
			}
		}
	}
}
