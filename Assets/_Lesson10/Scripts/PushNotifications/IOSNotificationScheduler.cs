#if UNITY_IOS
using Unity.Notifications.iOS;
#endif


namespace NikolayTrofimov_MobileGame_Lesson10
{
    internal sealed class IOSNotificationScheduler : INotificationScheduler
    {
        public void ScheduleNotification(NotificationData notificationData)
        {
#if UNITY_IOS
            var iosNotification = new iOSNotification
            {
                Identifier = notificationData.Id,
                Title = notificationData.Title,
                Body = notificationData.Text,
                Trigger = CreateIosTrigger(notificationData)
            };
#endif
        }

#if UNITY_IOS
        private iOSNotificationTrigger CreateIosTrigger(NotificationData notificationData) =>
            notificationData.RepeatType switch
            {
                NotificationRepeat.Once => new iOSNotificationCalendarTrigger()
                {
                    Year = notificationData.FireTime.Year,
                    Month = notificationData.FireTime.Month,
                    Day = notificationData.FireTime.Day,
                    Hour = notificationData.FireTime.Hour,
                    Minute = notificationData.FireTime.Minute
                },

                NotificationRepeat.Repeatable => new iOSNotificationTimeIntervalTrigger()
                {
                    Repeats = true,
                    TimeInterval = notificationData.RepeatInterval
                },

                _ => default
        };
#endif
    }
}
