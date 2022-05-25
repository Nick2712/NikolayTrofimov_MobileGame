using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal interface IItem
    {
        string Id { get; }
        string Title { get; }
        Sprite Icon { get; }
    }
}
