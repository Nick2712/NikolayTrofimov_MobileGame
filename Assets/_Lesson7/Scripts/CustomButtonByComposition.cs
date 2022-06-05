using DG.Tweening;
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
        }

        private void InitComponents()
        {
            _button ??= GetComponent<Button>();
            _rectTransform ??= GetComponent<RectTransform>();
        }

        private void OnButtonClick()
        {
            ActivateAnimation();
        }

        private void ActivateAnimation()
        {
            switch (_animationButtonType)
            {
                case AnimationButtonType.ChangeRotation:
                    _rectTransform.DOShakeRotation(_duration, Vector3.forward * _strength).SetEase(_curveEase);
                    break;
                case AnimationButtonType.ChangePosition:
                    _rectTransform.DOShakeAnchorPos(_strength, Vector2.one * _strength).SetEase(_curveEase);
                    break;
            }
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}
 