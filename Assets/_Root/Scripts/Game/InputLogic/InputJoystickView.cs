using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class InputJoystickView : BaseInputView
    {
        [SerializeField] private float _moveStepThreshold = 0.02f;

        private ProfilePlayer _profilePlayer;


        public void Init(SubscriptionProperty<float> horizontalMove, float speed, ProfilePlayer profilePlayer)
        {
            base.Init(horizontalMove, speed);

            _profilePlayer = profilePlayer;
            _profilePlayer.Pause.OnPause.Subscribe(OnPause);
        }

        protected override void Move(float deltatime)
        {
            var moveStep = CrossPlatformInputManager.GetAxis("Horizontal");
            if (moveStep > _moveStepThreshold || moveStep < -_moveStepThreshold)
            {
                _horizontalMove.Value = moveStep;
            }
            else
            {
                _horizontalMove.Value = 0;
            }
        }

        private void OnPause(bool isPause)
        {
            if (!isPause) CrossPlatformInputManager.UnRegisterVirtualAxis("Horizontal");
            gameObject.SetActive(!isPause);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            CrossPlatformInputManager.UnRegisterVirtualAxis("Horizontal");
            _profilePlayer.Pause.OnPause.Unsubscribe(OnPause);
        }
    }
}
