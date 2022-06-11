using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class RewardController : BaseController
    {
        private readonly string PERIOD_NAME = "Day";
        private const string VIEW_PATH = "RewardWindow";

        private readonly ProfilePlayer _profilePlayer;
        private readonly RewardView _view;

        private List<ContainerSlotRewardView> _slots;
        private Coroutine _coroutine;

        private bool _isGetReward;
        

        public RewardController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _view = LoadView<RewardView>(placeForUI, VIEW_PATH);
            _profilePlayer = profilePlayer;
            CreateCurrencyController(placeForUI, profilePlayer.Currency);

            Init();
        }

        private void CreateCurrencyController(Transform placeForUI, CurrencyModel currency)
        {
            var currencyController = new CurrencyController(currency, placeForUI);
            AddController(currencyController);
        }

        private void Init()
        {
            InitSlots();
            RefreshUI();
            StartRewardsUpdating();
            SubscribeButtons();
        }

        private void Deinit()
        {
            DeinitSlots();
            StopRewardsUpdating();
            UnsubscribeButtons();
        }

        private void InitSlots()
        {
            _slots = new List<ContainerSlotRewardView>();

            for (int i = 0; i < _view.Rewards.Count; i++)
            {
                ContainerSlotRewardView instanceSlot = CreateRewardView();
                _slots.Add(instanceSlot);
            }
        }

        private ContainerSlotRewardView CreateRewardView()
        {
            return UnityEngine.Object.Instantiate
            (
                _view.ContainerSlotRewardViewPrefab,
                _view.MountRootSlotReward,
                false
            );
        }

        private void StartRewardsUpdating()
        {
            _coroutine = _view.StartCoroutine(RewardStateUpdater());
        }

        private void StopRewardsUpdating()
        {
            if (_coroutine == null) return;

            _view.StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator RewardStateUpdater()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(1);

            while (true)
            {
                RefreshRewardsState();
                RefreshUI();
                yield return waitForSeconds;
            }
        }

        private void SubscribeButtons()
        {
            _view.GetRewardButton.onClick.AddListener(ClaimReward);
            _view.ResetButton.onClick.AddListener(ResetRewardsState);
            _view.CloseButton.onClick.AddListener(Close);
        }

        private void UnsubscribeButtons()
        {
            _view.GetRewardButton.onClick.RemoveListener(ClaimReward);
            _view.ResetButton.onClick.RemoveListener(ResetRewardsState);
            _view.CloseButton.onClick.RemoveListener(Close);
        }

        private void ClaimReward()
        {
            if (!_isGetReward) return;

            Reward reward = _view.Rewards[_view.CurrencySlotInActive];

            switch (reward.RewardType)
            {
                case RewardType.Wood:
                    _profilePlayer.Currency.Wood.Value += reward.Count;
                    break;
                case RewardType.Diamond:
                    _profilePlayer.Currency.Diamond.Value += reward.Count;
                    break;
            }

            _view.TimeGetReward = DateTime.UtcNow;
            _view.CurrencySlotInActive++;
            _isGetReward = false;

            RefreshRewardsState();
        }

        private void RefreshRewardsState()
        {
            bool gotRewardEarlier = _view.TimeGetReward.HasValue;

            if (!gotRewardEarlier)
            {
                _isGetReward = true;
                return;
            }

            if (!_isGetReward)
            {
                TimeSpan timeFromLastRewardGetting = DateTime.UtcNow - _view.TimeGetReward.Value;

                bool isTimeToGetNewReward = timeFromLastRewardGetting.TotalSeconds >= _view.TimeCooldown;

                _isGetReward = isTimeToGetNewReward;
            }
        }

        private void ResetRewardsState()
        {
            _view.TimeGetReward = null;
            _view.CurrencySlotInActive = 0;
        }

        private void RefreshUI()
        {
            _view.GetRewardButton.interactable = _isGetReward;
            _view.TimerNewReward.text = GetTimerNewRewardText();
            RefreshSlot();
        }

        private string GetTimerNewRewardText()
        {
            if (_isGetReward) return "Reward is ready to be received!";
            if (_view.TimeGetReward.HasValue)
            {
                DateTime nextClaimTime = _view.TimeGetReward.Value.AddSeconds(_view.TimeCooldown);
                TimeSpan currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

                string timeGetReward =
                    $"{currentClaimCooldown.Days:D2}:{currentClaimCooldown.Hours:D2}:" +
                    $"{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

                return $"Time to get the next reward: {timeGetReward}";
            }

            return string.Empty;
        }

        private void RefreshSlot()
        {
            for (int i = 0; i < _slots.Count; i++)
            {
                Reward reward = _view.Rewards[i];
                int countDay = i + 1;
                bool isSelected = i == _view.CurrencySlotInActive;

                _slots[i].SetData(reward, countDay, isSelected, PERIOD_NAME);
            }
        }

        private void DeinitSlots()
        {
            foreach (ContainerSlotRewardView instanceSlot in _slots)
            {
                UnityEngine.Object.Destroy(instanceSlot.gameObject);
            }

            _slots.Clear();
        }

        private void Close()
        {
            _profilePlayer.GameState.Value = GameState.MainMenu;
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            Deinit();
        }
    }
}
