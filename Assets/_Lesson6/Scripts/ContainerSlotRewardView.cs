using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson6
{
    internal class ContainerSlotRewardView : MonoBehaviour
    {
        [SerializeField] private Image _originalBackground;
        [SerializeField] private Image _selectBackground;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _days;
        [SerializeField] private TMP_Text _count;


        public void SetData(Reward reward, int countDay, bool isSelected, string periodName)
        {
            _icon.sprite = reward.Icon;
            _days.text = $"{periodName} {countDay}";
            _count.text = reward.Count.ToString();

            UpdateBackground(isSelected);
        }

        private void UpdateBackground(bool isSelected)
        {
            _originalBackground.gameObject.SetActive(!isSelected);
            _selectBackground.gameObject.SetActive(isSelected);
        }
    }
}
