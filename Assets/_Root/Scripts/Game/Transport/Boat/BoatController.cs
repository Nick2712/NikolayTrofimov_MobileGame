namespace NikolayTrofimov_MobileGame
{
    internal sealed class BoatController : TransportController
    {
        private const string VIEW_PATH = "Boat";

        protected override string ViewPath()
        {
            return VIEW_PATH;
        }
    }
}
