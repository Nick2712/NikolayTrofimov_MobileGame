using System;
using UnityEngine;
using UnityEngine.Purchasing;


namespace NikolayTrofimov_MobileGame
{
    [Serializable]
    internal sealed class Product
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public ProductType ProductType { get; private set; }
    }
}
