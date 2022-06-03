using System;
using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson6
{
    [Serializable]
    internal sealed class Reward
    {
        [field: SerializeField] public RewardType RewardType { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
    }
}
