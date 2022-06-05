using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson7
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(RectTransform))]
    public class CustomButtonByComposition : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Button _button;
        [SerializeField] private RectTransform _rectTransform;

        [Header("Settings")]
        [SerializeField] private AnimationButtonType _animationButtonType = AnimationButtonType.ChangePosition;
        [SerializeField] private Ease _curveEase = Ease.Linear;
        [SerializeField] private float _duration = 0.6f;
        [SerializeField] private float _strength = 30.0f;

        private Tweener _tweener;
        private AnimationButtonPlayer _animationPlayer;
        

        [ContextMenu(nameof(Play))]
        public void Play()
        {
            Stop();

            OnButtonClick();
        }

        [ContextMenu(nameof(Stop))]
        public void Stop()
        {
            if (!_animationPlayer.IsAnimationPlaying) return;

            _tweener.Kill(true);
        }

        private void OnValidate()
        {
            InitComponents();
        }

        private void Awake()
        {
            InitComponents();
        }

        private void Start()
        {
            _button.onClick.AddListener(OnButtonClick);
            _animationPlayer = new AnimationButtonPlayer(_rectTransform);
        }

        private void InitComponents()
        {
            _button ??= GetComponent<Button>();
            _rectTransform ??= GetComponent<RectTransform>();
        }

        private void OnButtonClick()
        {
            _tweener = _animationPlayer.ActivateAnimation(_animationButtonType, _duration, _strength, _curveEase);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}
 