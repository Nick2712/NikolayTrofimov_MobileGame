using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal abstract class TransportController : BaseController, IAbilityActivator
    {
        private readonly IAbilityActivator _view;

        public GameObject ViewGameObject => _view.ViewGameObject;

        public TransportController()
        {
            _view = LoadView();
        }

        private IAbilityActivator LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(ViewPath());
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            return objectView.GetComponent<IAbilityActivator>();
        }

        protected abstract string ViewPath();
    }
}
