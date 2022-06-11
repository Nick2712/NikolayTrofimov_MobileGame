using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class CurrencyView : MonoBehaviour
    {
        [field: SerializeField] public CurrencySlotView CurrencyWood { get; private set; }
        [field: SerializeField] public CurrencySlotView CurrencyDiamond { get; private set; }


        public void Init(int currentWoodValue, int currentDiamondValue)
        {
            CurrencyWood.SetData(currentWoodValue);
            CurrencyDiamond.SetData(currentDiamondValue);
        }
    }
}
