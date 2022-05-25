using UnityEngine.Events;


namespace NikolayTrofimov_MobileGame
{
    internal interface IShedView
    {
        void Init(UnityAction aply, UnityAction back);
        void Deinit();
    }
}
