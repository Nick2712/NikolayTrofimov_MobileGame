using DG.Tweening;
using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson7
{
    internal sealed class AnimationButtonPlayer
    {
        public bool IsAnimationPlaying { get; private set; }
        private RectTransform _rectTransform;
        private readonly RectTransform _defaultPosition;


        public AnimationButtonPlayer(RectTransform rectTransform)
        {
            _rectTransform = rectTransform;
            _defaultPosition = rectTransform;
        }

        public Tweener ActivateAnimation(AnimationButtonType animationButtonType, float duration,
            float strength, Ease curveEase)
        {
            IsAnimationPlaying = true;

            return animationButtonType switch
            {
                AnimationButtonType.ChangeRotation => _rectTransform
                                        .DOShakeRotation(duration, Vector3.forward * strength)
                                        .SetEase(curveEase)
                                        .OnComplete(OnStopAnimation),
                AnimationButtonType.ChangePosition => _rectTransform
                                        .DOShakeAnchorPos(duration, Vector2.one * strength)
                                        .SetEase(curveEase)
                                        .OnComplete(OnStopAnimation),
                _ => null,
            };
        }

        private void OnStopAnimation()
        {
            IsAnimationPlaying = false;
            _rectTransform = _defaultPosition;
        }
    }
}
