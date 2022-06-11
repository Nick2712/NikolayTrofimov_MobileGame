using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class CurrencyController : BaseController
    {
        private const string RESOURCE_PATH = "CurrencyView";
        public const string WOOD_KEY = nameof(WOOD_KEY);
        public const string DIAMOND_KEY = nameof(DIAMOND_KEY);

        private readonly CurrencyModel _model;
        private readonly CurrencyView _view;

        public CurrencyController(CurrencyModel model, Transform placeForUI)
        {
            _model = model;
            
            _view = LoadView<CurrencyView>(placeForUI, RESOURCE_PATH);
            _view.Init(_model.Wood.Value, _model.Diamond.Value);

            Subscribe();
        }

        private void Subscribe()
        {
            _model.Wood.Subscribe(OnWoodValueChanged);
            _model.Diamond.Subscribe(OnDaimondValueChanged);
        }

        private void Unsubscribe()
        {
            _model.Wood.Unsubscribe(OnWoodValueChanged);
            _model.Diamond.Unsubscribe(OnDaimondValueChanged);
        }

        private void OnWoodValueChanged(int value)
        {
            PlayerPrefs.SetInt(WOOD_KEY, value);
            _view.CurrencyWood.SetData(value);
        }

        private void OnDaimondValueChanged(int value)
        {
            PlayerPrefs.SetInt(DIAMOND_KEY, value);
            _view.CurrencyDiamond.SetData(value);
        }

        protected override void OnDispose()
        {
            Unsubscribe();

            base.OnDispose();
        }
    }
}
