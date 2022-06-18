using System;

#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

namespace NikolayTrofimov_MobileGame_Lesson10
{
    internal sealed class AndroidNotificationScheduler : INotificationScheduler
    {
        public void RegisterChanel(ChannelSettings channelSettings)
        {
#if UNITY_ANDROID
            var androidNotificanionChanel = new AndroidNotificationChannel
                (
                channelSettings.Id,
                channelSettings.Name,
                channelSettings.Description,
                channelSettings.Importance
                );

            AndroidNotificationCenter.RegisterNotificationChannel(androidNotificanionChanel);
#endif
        }

        public void ScheduleNotification(NotificationData notificationData)
        {
#if UNITY_ANDROID
            AndroidNotification androidNotification = CreateAndroidNotification(notificationData);
            AndroidNotificationCenter.SendNotification(androidNotification, notificationData.Id);
#endif
        }

#if UNITY_ANDROID
        private AndroidNotification CreateAndroidNotification(NotificationData notificationData) =>
        notificationData.RepeatType switch
        {
            NotificationRepeat.Once => new AndroidNotification
            (
                notificationData.Title,
                notificationData.Text,
                notificationData.FireTime
                ),

            NotificationRepeat.Repeatable => new AndroidNotification
            (
                notificationData.Title,
                notificationData.Text,
                notificationData.FireTime,
                notificationData.RepeatInterval
                ),

            _ => throw new ArgumentOutOfRangeException(nameof(notificationData.RepeatType))
        };
#endif
    }
}
