using System;
using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson9
{
    [Serializable]
    internal class AudioBundleData
    {
        [field: SerializeField] public string NameAssetBundle { get; private set; }
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
    }
}