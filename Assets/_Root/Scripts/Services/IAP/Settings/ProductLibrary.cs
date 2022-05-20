using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [CreateAssetMenu(fileName = nameof(ProductLibrary), menuName = Constants.MOBILE_GAME + nameof(ProductLibrary))]
    internal class ProductLibrary : ScriptableObject
    {
        [field: SerializeField] public Product[] Products { get; private set; }
    }
}
