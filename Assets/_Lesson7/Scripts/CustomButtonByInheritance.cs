using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using NikolayTrofimov_MobileGame;


namespace NikolayTrofimov_MobileGame_Lesson7
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]
    public class CustomButtonByInheritance : Button
    {
        public static string AnimationTypeName => nameof(_animationButtonType);
        public static string CurveEaseName => nameof(_curveEase);
        public static string AnimationDurationName => nameof(_animationDuration);
        public static string StrengthName => nameof(_strength);
        public static string NewColorName => nameof(_newColor);
        public static string ColorChangingDuration => nameof(_colorChangingDuration);

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;

        [SerializeField] private AnimationButtonType _animationButtonType = AnimationButtonType.ChangeRotation;
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

        protected override void Awake()
        {
            base.Awake();
            InitComponents();
            _animationPlayer = new AnimationButtonPlayer(_rectTransform);

            _defaultColor = _image.color;
            _colorButtonChanger = new ColorButtonChanger(_image);
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            InitComponents();
        }

        private void InitComponents()
        {
            _rectTransform ??= GetComponent<RectTransform>();
            _image ??= GetComponent<Image>();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            StartAnimation();
            StartChangeColor();
        }

        private void StartAnimation()
        {
            _animationPlayer.TryStopAnimation();

            _animationPlayer.TryActivateAnimation(_animationButtonType, _animationDuration, _strength, _curveEase);
        }

        private void StartChangeColor()
        {
            if (_image.color == _defaultColor) _colorButtonChanger.TryStartChangeColor(_newColor, _colorChangingDuration);
            else _colorButtonChanger.TryStartChangeColor(_defaultColor, _colorChangingDuration);
        }
    }
}
