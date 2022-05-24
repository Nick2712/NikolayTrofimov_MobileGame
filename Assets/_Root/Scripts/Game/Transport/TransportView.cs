using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal abstract class TransportView : MonoBehaviour, IAbilityActivator
    {
        [field: SerializeField] public GameObject ViewGameObject { get; private set; }
    }
}
