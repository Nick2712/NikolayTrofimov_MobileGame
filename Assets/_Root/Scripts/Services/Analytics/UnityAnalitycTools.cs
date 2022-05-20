using System.Collections.Generic;
using UnityEngine.Analytics;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class UnityAnalitycTools : IAnalyticTools
    {
        private static UnityAnalitycTools _unityAnalitycTools;

        public static UnityAnalitycTools Instance
        {
            get
            {
                if (_unityAnalitycTools == null) _unityAnalitycTools = new UnityAnalitycTools();
                return _unityAnalitycTools;
            }
        }


        private UnityAnalitycTools()
        {

        }


        public void SendMessage(string message, Dictionary<string, object> data = null)
        {
            if (data == null) Analytics.CustomEvent(message);
            else Analytics.CustomEvent(message, data);
        }
    }
}
