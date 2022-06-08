using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(RectTransform))]
    
    public class AnimationButtonComponent : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Button _button;
        [SerializeField] private RectTransform _rectTransform;
        
        [Header("Settings")]
        [SerializeField] private AnimationButtonType _animationButtonType = 
            AnimationButtonType.ChangePosition;
        [SerializeField] private Ease _curveEase = Ease.Linear;
        [SerializeField] private float _animationDuration = 0.6f;
        [SerializeField] private float _strength = 30.0f;
        
        private AnimationButtonPlayer _animationPlayer;


        private void OnValidate() => InitComponents();
        private void Awake() => InitComponents();
        
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

        private void OnButtonClick() => StartAnimation();
        
        private void StartAnimation()
        {
            _animationPlayer.TryStopAnimation();

            _animationPlayer.TryActivateAnimation(_animationButtonType,
                _animationDuration, _strength, _curveEase);
        }

        private void OnDestroy() => _button.onClick.RemoveAllListeners();
    }
}
