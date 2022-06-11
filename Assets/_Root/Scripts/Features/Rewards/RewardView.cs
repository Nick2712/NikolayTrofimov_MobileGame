using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class RewardView : MonoBehaviour
    {
        private const string CURRENCY_SLOT_IN_ACTIVE_KEY = nameof(CURRENCY_SLOT_IN_ACTIVE_KEY);
        private const string TIME_GET_REWARD_KEY = nameof(TIME_GET_REWARD_KEY);

        [Header("Settings Time Get Reward")]
        [SerializeField] private float _timeCooldown = 86400;
        
        [field: Header("Settings Rewards")]
        [field: SerializeField] public List<Reward> Rewards { get; private set; }

        [field: Header("UI Elements")]
        [field: SerializeField] public TMP_Text TimerNewReward { get; private set; }
        [field: SerializeField] public Transform MountRootSlotReward { get; private set; }
        [field: SerializeField] public ContainerSlotRewardView ContainerSlotRewardViewPrefab { get; private set; }
        [field: SerializeField] public Button GetRewardButton { get; private set; }
        [field: SerializeField] public Button ResetButton { get; private set; }
        [field: SerializeField] public Button CloseButton { get; private set; }

        public float TimeCooldown => _timeCooldown;
        

        public int CurrencySlotInActive
        {
            get => PlayerPrefs.GetInt(CURRENCY_SLOT_IN_ACTIVE_KEY);
            set
            {
                if (value >= Rewards.Count) value = 0;
                PlayerPrefs.SetInt(CURRENCY_SLOT_IN_ACTIVE_KEY, value);
            }
        }

        public DateTime? TimeGetReward
        {
            get
            {
                string data = PlayerPrefs.GetString(TIME_GET_REWARD_KEY);
                return !string.IsNullOrEmpty(data) ? DateTime.Parse(data) : null;
            }
            set
            {
                if (value != null) PlayerPrefs.SetString(TIME_GET_REWARD_KEY, value.ToString());
                else PlayerPrefs.DeleteKey(TIME_GET_REWARD_KEY);
            }
        }
    }
}
