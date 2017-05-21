using System;
using Foundation;
using UIKit;
using UserNotifications;
using WindowsAzure.Messaging;

namespace XamarinFormsPushNotification.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        SBNotificationHub Hub;
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            NotificationSettings();

            var category = UNNotificationCategory.FromIdentifier("techTalks", new UNNotificationAction[] { }, new string[] { }, UNNotificationCategoryOptions.None);
            UNUserNotificationCenter.Current.SetNotificationCategories(new NSSet<UNNotificationCategory>(category));

            UNUserNotificationCenter.Current.Delegate = new NotificationDelegate();


            return base.FinishedLaunching(app, options);
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            this.Hub = new SBNotificationHub(Constants.ConnectionString, Constants.NotificationHub);
            this.Hub.RegisterNativeAsync(deviceToken, null, (error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Registration Failed");
                }
            });
        }

        private void NotificationSettings()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert
                                                                                 | UIUserNotificationType.Badge
                                                                                 | UIUserNotificationType.Sound, new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();

            }
            else
            {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert |
                                                                                     UIRemoteNotificationType.Badge |
                                                                                     UIRemoteNotificationType.Sound;

                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }
        }

    }

    public class NotificationDelegate : UNUserNotificationCenterDelegate
    {
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            completionHandler(UNNotificationPresentationOptions.Alert);
        }
    }
}
