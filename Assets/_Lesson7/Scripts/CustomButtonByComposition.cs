using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson7
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]

    public class CustomButtonByComposition : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Button _button;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;

        [Header("Settings")]
        [SerializeField] private AnimationButtonType _animationButtonType = AnimationButtonType.ChangePosition;
        [SerializeField] private Ease _curveEase = Ease.Linear;
        [SerializeField] private float _animationDuration = 0.6f;
        [SerializeField] private float _strength = 30.0f;
        [SerializeField] private Color _newColor = Color.red;
        [SerializeField] private float _colorChangingDuration = 0.6f;

        private AnimationButtonPlayer _animationPlayer;

        private Color _defaultColor;
        private ColorButtonChanger _colorButtonChanger;


        [ContextMenu(nameof(Play))]
        public void Play()
        {
            Stop();

            StartAnimation();
        }

        [ContextMenu(nameof(Stop))]
        public void Stop()
        {
            _animationPlayer.TryStopAnimation();
        }

        [ContextMenu(nameof(ChangeColor))]
        public void ChangeColor()
        {
            StartChangeColor();
        }

        [ContextMenu(nameof(ResetColor))]
        public void ResetColor()
        {
            _colorButtonChanger.TryStopColorChanging();
            _colorButtonChanger.ResetColor();
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

            _defaultColor = _image.color;
            _colorButtonChanger = new ColorButtonChanger(_image);
        }

        private void InitComponents()
        {
            _button ??= GetComponent<Button>();
            _rectTransform ??= GetComponent<RectTransform>();
            _image ??= GetComponent<Image>();
        }

        private void OnButtonClick()
        {
            StartAnimation();
            StartChangeColor();
        }

        private void StartAnimation()
        {
            _animationPlayer.TryStopAnimation();

            _animationPlayer.TryActivateAnimation(_animationButtonType,
                _animationDuration, _strength, _curveEase);
        }

        private void StartChangeColor()
        {
            if (_image.color == _defaultColor) _colorButtonChanger.TryStartChangeColor(_newColor, _colorChangingDuration);
            else _colorButtonChanger.TryStartChangeColor(_defaultColor, _colorChangingDuration);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}
