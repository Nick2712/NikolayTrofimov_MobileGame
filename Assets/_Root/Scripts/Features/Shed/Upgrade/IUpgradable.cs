using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikolayTrofimov_MobileGame
{
    internal interface IUpgradable
    {
        float Speed { get; set; }
        void Restore();
    }
}
