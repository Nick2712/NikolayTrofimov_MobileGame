using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class InputJoystickView : BaseInputView
    {
        [SerializeField] private float _moveStepThreshold = 0.02f;
        
        
        protected override void Move(float deltatime)
        {
            var moveStep = CrossPlatformInputManager.GetAxis("Horizontal");
            if(moveStep > _moveStepThreshold || moveStep < -_moveStepThreshold)
            {
                _horizontalMove.Value = moveStep;
            }
            else
            {
                _horizontalMove.Value = 0;
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            CrossPlatformInputManager.UnRegisterVirtualAxis("Horizontal");
        }
    }
}
