using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = Constants.MOBILE_GAME + nameof(GameSettings))]
    internal sealed class GameSettings : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; } = 20;
        [field: SerializeField] public float JumpHeight { get; private set; } = 10;
        [field: SerializeField] public Transport Transport { get; private set; } = Transport.Car;
    }
}
