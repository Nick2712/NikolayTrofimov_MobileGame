using System;
using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson10
{
    [Serializable]
    internal sealed class Span
    {
        [field: SerializeField, Min(0)] public int Seconds { get; private set; }


        public override string ToString() => Seconds.ToString();

        public static implicit operator TimeSpan(Span span) => TimeSpan.FromSeconds(span.Seconds);
    }
}
