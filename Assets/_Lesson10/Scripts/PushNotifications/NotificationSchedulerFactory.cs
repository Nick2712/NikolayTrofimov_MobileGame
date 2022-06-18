namespace NikolayTrofimov_MobileGame_Lesson10
{
    internal sealed class NotificationSchedulerFactory
    {
        private readonly NotificationSettings _notificationSettings;

        public NotificationSchedulerFactory(NotificationSettings notificationSettings) =>
            _notificationSettings = notificationSettings;

        public INotificationScheduler Create()
        {
#if UNITY_EDITOR
            return new StubNotificationScgeduler();
#elif UNITY_ANDROID
            var scheduler = new AndroidNotificationScheduler();
            foreach (ChannelSettings channelSettings in _notificationSettings.Channels)
                scheduler.RegisterChanel(channelSettings);

            return scheduler;
#elif UNITY_IOS
            return new IOSNotificationScheduler();
#else
            return new StubNotificationScgeduler();
#endif
        }
    }
}
