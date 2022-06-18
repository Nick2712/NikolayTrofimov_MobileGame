using System;
using TMPro;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [Serializable]
    public class LocalizationOptions
    {
        [field: SerializeField] public string Key { get; private set; }
        [field: SerializeField] public TMP_Text TextField { get; private set; }
    }
}
