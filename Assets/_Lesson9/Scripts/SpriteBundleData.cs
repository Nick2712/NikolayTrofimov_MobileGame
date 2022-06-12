using System;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson9
{
    [Serializable]
    internal sealed class SpriteBundleData
    {
        [field: SerializeField] public string NameAssetBundle { get; private set; }
        [field: SerializeField] public Image Image { get; private set; }
    }
}
