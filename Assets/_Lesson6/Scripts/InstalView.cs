using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson6
{
    public class InstalView : MonoBehaviour
    {
        [SerializeField] private DailyRewardView _view;

        private DailyRewardController _controller;

        private void Awake()
        {
            _controller = new DailyRewardController(_view);
        }

        private void Start()
        {
            _controller.Init();
        }

        private void OnDestroy()
        {
            _controller.Deinit();
        }
    }
}
