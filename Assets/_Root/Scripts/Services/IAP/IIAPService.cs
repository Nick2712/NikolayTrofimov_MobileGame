using UnityEngine.Events;


namespace NikolayTrofimov_MobileGame
{
    internal interface IIAPService
    {
        UnityEvent Initialized { get; }
        UnityEvent PurchaseSucceed { get; }
        UnityEvent PurchaseFailed { get; }
        bool IsInitialized { get; }

        void Buy(string id);
        string GetCost(string productId);
        void RestorePurchases();
    }
}
