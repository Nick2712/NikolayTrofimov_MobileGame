using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal abstract class BaseInputView : MonoBehaviour
    {
        protected SubscriptionProperty<float> _horizontalMove;
        protected float _speed;

        public virtual void Init(SubscriptionProperty<float> horizontalMove, float speed)
        {
            _horizontalMove = horizontalMove;
            _speed = speed;
        }

        protected virtual void OnHorizontalMove(float value)
        {
            _horizontalMove.Value = value;
        }
    }
}
