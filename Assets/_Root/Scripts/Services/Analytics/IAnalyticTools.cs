using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal interface IAnalyticTools
    {
        void SendMessage(string message, Dictionary<string, object> data = null);
    }
}
