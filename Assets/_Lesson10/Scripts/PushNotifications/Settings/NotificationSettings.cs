using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson10
{
    [CreateAssetMenu(fileName = nameof(NotificationSettings), menuName = "Notifications" + nameof(NotificationSettings))]
    internal class NotificationSettings : ScriptableObject
    {
        [field: SerializeField] public ChannelSettings[] Channels { get; private set; }
        [field: SerializeField] public NotificationData[] Notifications { get; private set; }
    }
}
