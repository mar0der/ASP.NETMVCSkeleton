namespace Exam.App.Extensions
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    #endregion

    public static class NotificationExtensions
    {
        private static readonly IDictionary<string, string> NotificationKey = new Dictionary<string, string>
                                                                                  {
                                                                                      {
                                                                                          "Error",
                                                                                          "App.Notifications.Error"
                                                                                      },
                                                                                      {
                                                                                          "Warning",
                                                                                          "App.Notifications.Warning"
                                                                                      },
                                                                                      {
                                                                                          "Success",
                                                                                          "App.Notifications.Success"
                                                                                      },
                                                                                      {
                                                                                          "Info",
                                                                                          "App.Notifications.Info"
                                                                                      }
                                                                                  };

        public static void AddNotification(this ControllerBase controller, string message, string notificationType)
        {
            var NotificationKey = getNotificationKeyByType(notificationType);
            var messages = controller.TempData[NotificationKey] as ICollection<string>;

            if (messages == null)
            {
                controller.TempData[NotificationKey] = (messages = new HashSet<string>());
            }

            messages.Add(message);
        }

        public static IEnumerable<string> GetNotifications(this HtmlHelper htmlHelper, string notificationType)
        {
            var NotificationKey = getNotificationKeyByType(notificationType);
            return htmlHelper.ViewContext.Controller.TempData[NotificationKey] as ICollection<string> ?? null;
        }

        private static string getNotificationKeyByType(string notificationType)
        {
            try
            {
                return NotificationKey[notificationType];
            }
            catch (IndexOutOfRangeException e)
            {
                var exception = new ArgumentException("Key is invalid", "notificationType", e);
                throw exception;
            }
        }
    }

    public static class NotificationType
    {
        public const string ERROR = "Error";

        public const string WARNING = "Warning";

        public const string SUCCESS = "Success";

        public const string INFO = "Info";
    }
}