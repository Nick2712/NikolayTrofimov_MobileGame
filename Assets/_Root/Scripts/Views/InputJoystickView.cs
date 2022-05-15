using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class InputJoystickView : BaseInputView
    {
        [SerializeField] private float _notMoveJoystickPosition = 0.02f;

        public override void Init(SubscriptionProperty<float> horizontalMove, float speed)
        {
            base.Init(horizontalMove, speed);
            UpdateManager.UpdateAction += Move;
        }

        private void Move(float deltatime)
        {
            var moveStep = CrossPlatformInputManager.GetAxis("Horizontal");
            if(moveStep > _notMoveJoystickPosition || moveStep < -_notMoveJoystickPosition)
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
