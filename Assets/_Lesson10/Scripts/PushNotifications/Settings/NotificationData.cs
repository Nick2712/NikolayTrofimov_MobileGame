using System;
using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson10
{
    [Serializable]
    internal class NotificationData
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public string Text { get; private set; }
        [field: SerializeField] public NotificationRepeat RepeatType { get; private set; }
        [field: SerializeField] public Date FireTime { get; private set; }
        [field: SerializeField] public Span RepeatInterval { get; private set; }

        public override string ToString() => $"{Id}: {Title}.{Text}. {RepeatType:F}, {FireTime}, {RepeatInterval}";
    }
}
