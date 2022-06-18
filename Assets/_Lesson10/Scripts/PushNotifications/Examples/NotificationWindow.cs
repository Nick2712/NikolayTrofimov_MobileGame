using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson10
{
    internal sealed class NotificationWindow : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private NotificationSettings _settings;

        [Header("Scene components")]
        [SerializeField] private Button _notificationButton;

        private INotificationScheduler _scheduler;

        private void Awake()
        {
            var schedulerFactory = new NotificationSchedulerFactory(_settings);
            _scheduler = schedulerFactory.Create();
        }

        private void OnEnable()
        {
            _notificationButton.onClick.AddListener(CreateNotification);
        }

        private void OnDisable()
        {
            _notificationButton.onClick.RemoveAllListeners();
        }

        private void CreateNotification()
        {
            foreach(var notificationData in _settings.Notifications)
                _scheduler.ScheduleNotification(notificationData);
        }
    }
}
