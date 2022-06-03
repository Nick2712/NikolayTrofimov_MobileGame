using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson6
{
    internal sealed class CurrencyVeiw : MonoBehaviour
    {
        private const string WOOD_KEY = nameof(WOOD_KEY);
        private const string DIAMOND_KEY = nameof(DIAMOND_KEY);

        private static CurrencyVeiw _instance;
        public static CurrencyVeiw Inctance => _instance;

        [SerializeField] private CurrencySlotView _currencyWood;
        [SerializeField] private CurrencySlotView _currencyDiamond;

        private int Wood 
        {
            get => PlayerPrefs.GetInt(WOOD_KEY); 
            set => PlayerPrefs.SetInt(WOOD_KEY, value); 
        }
        private int Diamond 
        {
            get => PlayerPrefs.GetInt(DIAMOND_KEY);
            set => PlayerPrefs.SetInt(DIAMOND_KEY, value);
        }


        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            _currencyWood.SetData(Wood);
            _currencyDiamond.SetData(Diamond);
        }

        public void AddWood(int value)
        {
            Wood += value;
            _currencyWood.SetData(Wood);
        }

        public void AddDiamond(int value)
        {
            Diamond += value;
            _currencyDiamond.SetData(Diamond);
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}
