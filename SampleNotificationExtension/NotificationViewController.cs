using System;
using Foundation;
using UIKit;
using UserNotifications;
using UserNotificationsUI;


namespace SampleNotificationExtension
{
    public partial class NotificationViewController : UIViewController, IUNNotificationContentExtension
    {
        protected NotificationViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any required interface initialization here.
        }

        public void DidReceiveNotification(UNNotification notification)
        {
            var content = notification.Request.Content;
            GetImage(content);
        }

        private void GetImage(UNNotificationContent notification)
        {
            NSData data = NSData.FromUrl(new NSUrl(notification.UserInfo[new NSString("tech")].ToString()));
            MyImageView.Image = UIImage.LoadFromData(data);
        }
    }
}
