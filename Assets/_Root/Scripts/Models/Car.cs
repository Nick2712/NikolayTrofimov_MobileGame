namespace NikolayTrofimov_MobileGame
{
    internal sealed class TransportModel : IUpgradable
    {
        public float Speed { get; set; }
        private readonly float _defaultSpeed;
        public readonly Transport Type;

        public TransportModel(float speed, Transport type)
        {
            Speed = speed;
            _defaultSpeed = speed;
            Type = type;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }
}
