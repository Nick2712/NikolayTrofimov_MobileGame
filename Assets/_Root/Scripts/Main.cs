using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class Main : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUI;
        [SerializeField] private float _speed = 20;
        [SerializeField] private Transport _transport = Transport.Car;
        private MainController _controller;


        private void Awake()
        {
            _controller = new MainController(_placeForUI, _speed, _transport);
        }

        private void Update()
        {
            UpdateManager.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            UpdateManager.FixedUpdate(Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _controller?.Dispose();
        }
    }
}