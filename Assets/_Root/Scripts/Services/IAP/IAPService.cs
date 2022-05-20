using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class IAPService : MonoBehaviour, IStoreListener, IIAPService
    {
        [Header("Components")]
        [SerializeField] private ProductLibrary _productLibrary;

        [field: Header("Events")]
        [field: SerializeField] public UnityEvent Initialized { get; private set; }

        [field: SerializeField] public UnityEvent PurchaseSucceed { get; private set; }

        [field: SerializeField] public UnityEvent PurchaseFailed { get; private set; }

        public bool IsInitialized { get; private set; }

        private IExtensionProvider _extensionProvider;
        private IStoreController _storeController;
        private PurchaseValidator _purchaseValidator;
        private PurchaseRestorer _purchaseRestorer;

        private void Awake()
        {
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            StandardPurchasingModule purchasingModule = StandardPurchasingModule.Instance();
            ConfigurationBuilder builder = ConfigurationBuilder.Instance(purchasingModule);

            foreach (Product product in _productLibrary.Products)
            {
                builder.AddProduct(product.Id, product.ProductType);
            }

            Debug.Log("Products initialized");
            UnityPurchasing.Initialize(this, builder);
        }

        void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            IsInitialized = true;
            _storeController = controller;
            _extensionProvider = extensions;
            _purchaseValidator = new PurchaseValidator();
            _purchaseRestorer = new PurchaseRestorer(_extensionProvider);

            Debug.Log("Initialized");
            Initialized?.Invoke();
        }

        void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
        {
            IsInitialized = false;
            Debug.Log("Initialization failed");
        }

        PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            if(_purchaseValidator.Validate(purchaseEvent))
            {
                PurchaseSucceed?.Invoke();
            }
            else
            {
                OnPurchaseFailed(purchaseEvent.purchasedProduct.definition.id, "NonValid");
            }

            return PurchaseProcessingResult.Complete;
        }
        
        void IStoreListener.OnPurchaseFailed(UnityEngine.Purchasing.Product product, PurchaseFailureReason failureReason)
        {
            OnPurchaseFailed(product.definition.id, failureReason.ToString());
        }

        private void OnPurchaseFailed(string productId, string reason)
        {
            Debug.Log($"Failed {productId}: {reason}");
            PurchaseFailed?.Invoke();
        }

        public void Buy(string id)
        {
            if(IsInitialized)
            {
                _storeController.InitiatePurchase(id);
            }
            else
            {
                Debug.Log($"Buy {id} FAIL. Not initialized.");
            }
        }

        public string GetCost(string productId)
        {
            UnityEngine.Purchasing.Product product = _storeController.products.WithID(productId);
            return product != null ? product.metadata.localizedPriceString : "N/A";
        }

        public void RestorePurchases()
        {
            if(IsInitialized)
            {
                _purchaseRestorer.Restore();
            }
            else
            {
                Debug.Log("Restore purchases FAIL. Not initialized.");
            }
        }
    }
}
