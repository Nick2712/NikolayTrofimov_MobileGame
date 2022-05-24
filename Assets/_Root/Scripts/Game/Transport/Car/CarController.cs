namespace NikolayTrofimov_MobileGame
{
    internal sealed class CarController : TransportController
    {
        private const string VIEW_PATH = "Car";
        
        protected override string ViewPath()
        {
            return VIEW_PATH;
        }
    }
}
