using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson7
{
    [RequireComponent(typeof(RectTransform))]
    public class CustomButtonByInheritance : Button
    {
        public static string AnimationTypeName => nameof(_animationButtonType);
        public static string CurveEaseName => nameof(_curveEase);
        public static string DurationName => nameof(_duration);
        public static string StrengthName => nameof(_strength);

        [SerializeField] private RectTransform _rectTransform;

        [SerializeField] private AnimationButtonType _animationButtonType = AnimationButtonType.ChangeRotation;
        [SerializeField] private Ease _curveEase = Ease.Linear;
        [SerializeField] private float _duration = 0.6f;
        [SerializeField] private float _strength = 30.0f;

        private Tweener _tweener;
        private AnimationButtonPlayer _animationPlayer;


        [ContextMenu(nameof(Play))]
        public void Play()
        {
            Stop();

            _tweener = _animationPlayer.ActivateAnimation(_animationButtonType, _duration, _strength, _curveEase);
        }

        [ContextMenu(nameof(Stop))]
        public void Stop()
        {
            if (!_animationPlayer.IsAnimationPlaying) return;

            _tweener.Kill(true);
        }

        protected override void Awake()
        {
            base.Awake();
            InitRectTransform();
            _animationPlayer = new AnimationButtonPlayer(_rectTransform);
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            InitRectTransform();
        }

        private void InitRectTransform()
        {
            _rectTransform ??= GetComponent<RectTransform>();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            _tweener = _animationPlayer.ActivateAnimation(_animationButtonType, _duration, _strength, _curveEase);
        }
    }
}
