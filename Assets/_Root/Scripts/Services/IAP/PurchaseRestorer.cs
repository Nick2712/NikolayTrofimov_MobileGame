using UnityEngine;
using UnityEngine.Purchasing;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class PurchaseRestorer
    {
        private readonly IExtensionProvider _extensionProvider;

        public PurchaseRestorer(IExtensionProvider extensionProvider)
        {
            _extensionProvider = extensionProvider;
        }

        public void Restore()
        {
            Debug.Log("Restore started ...");

            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.OSXPlayer:
                    _extensionProvider.GetExtension<IAppleExtensions>().RestoreTransactions(OnRestoredTransactions);
                    break;
                case RuntimePlatform.Android:
                    _extensionProvider.GetExtension<IGooglePlayStoreExtensions>().RestoreTransactions(OnRestoredTransactions);
                    break;
                default:
                    Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
                    break;
            }
        }

        private void OnRestoredTransactions(bool result)
        {
            Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
        }
    }
}
