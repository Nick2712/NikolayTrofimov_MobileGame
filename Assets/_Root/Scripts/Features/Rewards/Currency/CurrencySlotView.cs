using TMPro;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class CurrencySlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;

        public void SetData(int count) => _count.text = count.ToString();
    }
}
