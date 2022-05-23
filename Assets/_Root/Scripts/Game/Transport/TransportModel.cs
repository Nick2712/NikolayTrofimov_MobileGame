namespace NikolayTrofimov_MobileGame
{
    internal sealed class TransportModel : IUpgradable
    {
        private readonly float _defaultSpeed;

        public readonly Transport Type;

        public float Speed { get; set; }

        public TransportModel(float speed, Transport type)
        {
            _defaultSpeed = speed;
            Speed = speed;
            Type = type;
        }

        public void Restore() => Speed = _defaultSpeed;
    }
}
