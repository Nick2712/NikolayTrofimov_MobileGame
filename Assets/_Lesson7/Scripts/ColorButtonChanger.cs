using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson7
{
    internal sealed class ColorButtonChanger
    {
        public bool IsColorChanging { get; private set; }
        private readonly Image _image;
        private Tweener _tweener;
        private Color _defaultColor;


        public ColorButtonChanger(Image image)
        {
            _image = image;
            _defaultColor = _image.color;
        }

        public void TryStartChangeColor(Color color, float duration)
        {
            if (IsColorChanging) return;

            IsColorChanging = true;
            _tweener = _image.DOColor(color, duration).OnComplete(OnStopColorChanging);
        }

        private void OnStopColorChanging()
        {
            IsColorChanging = false;
        }

        public void TryStopColorChanging()
        {
            if (IsColorChanging) _tweener.Kill(true);
        }

        public void ResetColor()
        {
            _image.color = _defaultColor;
        }
    }
}
