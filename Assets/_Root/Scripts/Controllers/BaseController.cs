using System;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal abstract class BaseController : IDisposable
    {
        private List<BaseController> _controllers;
        private List<GameObject> _gameObjects;
        private List<IRepository> _repositorys;
        private bool _disposed;

        protected void AddController(BaseController controller)
        {
            if (_controllers == null) _controllers = new List<BaseController>();
            _controllers.Add(controller);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            if (_gameObjects == null) _gameObjects = new List<GameObject>();
            _gameObjects.Add(gameObject);
        }

        protected void AddRepositories(IRepository repository)
        {
            _repositorys ??= new List<IRepository>();
            _repositorys.Add(repository);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if( _controllers != null )
                {
                    foreach (BaseController controller in _controllers)
                    {
                        controller.Dispose();
                    }
                    _controllers.Clear();
                }
                if( _gameObjects != null )
                {
                    foreach(GameObject gameObject in _gameObjects)
                    {
                        UnityEngine.Object.Destroy(gameObject);
                    }
                    _gameObjects.Clear();
                }
                if( _repositorys != null )
                {
                    foreach(IRepository repository in _repositorys)
                    {
                        repository.Dispose();
                    }
                }
                _disposed = true;
                OnDispose();
            }
        }

        protected virtual void OnDispose()
        { }
    }
}
