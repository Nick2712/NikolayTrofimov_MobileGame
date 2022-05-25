using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class InputKeyboardView : BaseInputView
    {
        [SerializeField] private float _notMoveAxisPosition = 0.02f;

        public override void Init(SubscriptionProperty<float> horizontalMove, float speed)
        {
            base.Init(horizontalMove, speed);
            UpdateManager.UpdateAction += Move;
        }

        private void Move(float deltatime)
        {
            var moveStep = Input.GetAxis("Horizontal");
            if (moveStep > _notMoveAxisPosition || moveStep < -_notMoveAxisPosition)
            {
                _horizontalMove.Value = moveStep;
            }
            else
            {
                _horizontalMove.Value = 0;
            }
        }

        private void OnDestroy()
        {
            UpdateManager.UpdateAction -= Move;
        }
    }
}
