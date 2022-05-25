using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class InputKeyboardView : BaseInputView
    {
        [SerializeField] private float _moveStepThreshold = 0.02f;


        protected override void Move(float deltatime)
        {
            var moveStep = Input.GetAxis("Horizontal");
            if (moveStep > _moveStepThreshold || moveStep < -_moveStepThreshold)
            {
                _horizontalMove.Value = moveStep;
            }
            else
            {
                _horizontalMove.Value = 0;
            }
        }
    }
}
