using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson6
{
    internal sealed class DailyRewardController
    {
        private readonly DailyRewardView _view;

        private List<ContainerSlotRewardView> _slots;
        private Coroutine _coroutine;

        private bool _isGetReward;
        private bool _isInitialized;


        public DailyRewardController(DailyRewardView view)
        {
            _view = view;
        }

        public void Init()
        {
            if (_isInitialized) return;

            InitSlots();
            RefreshUI();
            StartRewardsUpdating();
            SubscribeButtons();

            _isInitialized = true;
        }

        public void Deinit()
        {
            if (!_isInitialized) return;

            DeinitSlots();
            StopRewardsUpdating();
            UnsubscribeButtons();

            _isInitialized = false;
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
        }

        private void UnsubscribeButtons()
        {
            _view.GetRewardButton.onClick.RemoveListener(ClaimReward);
            _view.ResetButton.onClick.RemoveListener(ResetRewardsState);
        }

        private void ClaimReward()
        {
            if (!_isGetReward) return;

            Reward reward = _view.Rewards[_view.CurrencySlotInActive];

            switch(reward.RewardType)
            {
                case RewardType.Wood:
                    CurrencyVeiw.Inctance.AddWood(reward.Count);
                    break;
                case RewardType.Diamond:
                    CurrencyVeiw.Inctance.AddDiamond(reward.Count);
                    break;
            }

            _view.TimeGetReward = DateTime.UtcNow;
            _view.CurrencySlotInActive++;

            RefreshRewardsState();
        }

        private void RefreshRewardsState()
        {
            bool gotRewardEarlier = _view.TimeGetReward.HasValue;

            if(!gotRewardEarlier)
            {
                _isGetReward = true;
                return;
            }

            TimeSpan timeFromLastRewardGetting = DateTime.UtcNow - _view.TimeGetReward.Value;

            bool isDeadLineElapsed = timeFromLastRewardGetting.Seconds >= _view.TimeDeadLine;
            bool isTimeToGetNewReward = timeFromLastRewardGetting.Seconds >= _view.TimeCooldown;

            if (isDeadLineElapsed) ResetRewardsState();

            _isGetReward = isTimeToGetNewReward;
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
            if(_view.TimeGetReward.HasValue)
            {
                DateTime nextClaimTime =_view.TimeGetReward.Value.AddSeconds(_view.TimeCooldown);
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

                _slots[i].SetData(reward, countDay, isSelected);
            }
        }

        private void DeinitSlots()
        {
            foreach(ContainerSlotRewardView instanceSlot in _slots)
            {
                UnityEngine.Object.Destroy(instanceSlot.gameObject);
            }

            _slots.Clear();
        }
    }
}
