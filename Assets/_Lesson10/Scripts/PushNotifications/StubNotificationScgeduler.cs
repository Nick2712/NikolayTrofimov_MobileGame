using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson10
{
    internal sealed class StubNotificationScgeduler : INotificationScheduler
    {
        public void ScheduleNotification(NotificationData notificationData) =>
            Debug.Log($"[{GetType()}] {notificationData}");
    }
}
