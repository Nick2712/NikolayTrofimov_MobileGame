using System;
using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson10
{
    [Serializable]
    internal sealed class Date
    {
        [field: SerializeField, Min(1)] public int Year { get; private set; }
        [field: SerializeField, Range(1, 12)] public int Month { get; private set; }
        [field: SerializeField, Range(1, 31)] public int Day { get; private set; }
        [field: SerializeField, Range(0, 23)] public int Hour { get; private set; }
        [field: SerializeField, Range(0, 59)] public int Minute { get; private set; }

        
        public static implicit operator DateTime(Date date) => new(
            date.Year, date.Month, date.Day, date.Hour, date.Minute, default);
    }
}
