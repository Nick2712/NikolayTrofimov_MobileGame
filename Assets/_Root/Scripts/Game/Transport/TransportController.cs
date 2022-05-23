using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal abstract class TransportController<TView> : BaseController, IAbilityActivator where TView : Component
    {
        private readonly TView _view;

        public GameObject ViewGameObject => _view.gameObject;

        public TransportController()
        {
            _view = LoadView();
        }

        private TView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(ViewPath());
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            return objectView.GetComponent<TView>();
        }

        protected abstract string ViewPath();
    }
}
