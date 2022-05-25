using System;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal abstract class BaseController : IDisposable
    {
        private List<GameObject> _gameObjects;
        private List<IDisposable> _disposables;
        private bool _disposed;

        protected void AddController(BaseController controller)
        {
            AddDisposable(controller);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            _gameObjects ??= new List<GameObject>();
            _gameObjects.Add(gameObject);
        }

        protected void AddRepositories(IRepository repository)
        {
            AddDisposable(repository);
        }

        private void AddDisposable(IDisposable disposable)
        {
            _disposables ??= new List<IDisposable>();
            _disposables.Add(disposable);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                DisposeDisposables();
                DestroyGameObjects();
                
                _disposed = true;
                OnDispose();
            }
        }

        private void DisposeDisposables()
        {
            if (_disposables != null)
            {
                foreach (IDisposable disposable in _disposables)
                {
                    disposable.Dispose();
                }
                _disposables.Clear();
            }
        }

        private void DestroyGameObjects()
        {
            if (_gameObjects != null)
            {
                foreach (GameObject gameObject in _gameObjects)
                {
                    UnityEngine.Object.Destroy(gameObject);
                }
                _gameObjects.Clear();
            }
        }

        protected virtual void OnDispose()
        { }
    }
}
