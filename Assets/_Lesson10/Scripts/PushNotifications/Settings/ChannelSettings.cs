using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson10
{
    [Serializable]
    internal sealed class ChannelSettings
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [SerializeField] private Importance _importance;

#if UNITY_ANDROID
        public Unity.Notifications.Android.Importance Importance => 
            (Unity.Notifications.Android.Importance)_importance;
#else
        public Impotance Impotance => _importance;
#endif
    }
}
