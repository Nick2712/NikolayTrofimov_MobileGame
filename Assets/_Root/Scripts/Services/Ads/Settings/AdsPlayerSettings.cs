using System;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [Serializable]
    internal sealed class AdsPlayerSettings
    {
        [field: SerializeField] public bool Enabled { get; private set; }
        [field: SerializeField] public string Id { get; private set; }
    }
}
