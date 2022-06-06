using DG.Tweening;
using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson7
{
    internal sealed class AnimationButtonPlayer
    {
        public bool IsAnimationPlaying { get; private set; }
        private readonly RectTransform _rectTransform;
        private Tweener _tweener;
        

        public AnimationButtonPlayer(RectTransform rectTransform)
        {
            _rectTransform = rectTransform;
        }

        public void TryActivateAnimation(AnimationButtonType animationButtonType, float duration,
            float strength, Ease curveEase)
        {
            if (IsAnimationPlaying) return;

            IsAnimationPlaying = true;

            switch (animationButtonType)
            {
                case AnimationButtonType.ChangeRotation:
                    _tweener = _rectTransform
                        .DOShakeRotation(duration, Vector3.forward * strength)
                        .SetEase(curveEase)
                        .OnComplete(OnStopAnimation);
                    break;
                case AnimationButtonType.ChangePosition:
                    _tweener = _rectTransform
                        .DOShakeAnchorPos(duration, Vector2.one * strength)
                        .SetEase(curveEase)
                        .OnComplete(OnStopAnimation);
                    break;
            }
        }

        private void OnStopAnimation()
        {
            IsAnimationPlaying = false;
        }

        public void TryStopAnimation()
        {
            if (IsAnimationPlaying) _tweener.Kill(true);
        }
    }
}
