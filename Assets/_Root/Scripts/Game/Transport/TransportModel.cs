namespace NikolayTrofimov_MobileGame
{
    internal sealed class TransportModel : IUpgradable
    {
        private readonly float _defaultSpeed;
        private readonly float _defaultJumpHeight;

        public readonly Transport Type;

        public float Speed { get; set; }
        public float JumpHeight { get; set; }

        public TransportModel(float speed, float jumpHeight, Transport type)
        {
            _defaultSpeed = speed;
            Speed = speed;
            Type = type;

            _defaultJumpHeight = jumpHeight;
            JumpHeight = jumpHeight;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
            JumpHeight = _defaultJumpHeight;
        }
    }
}
