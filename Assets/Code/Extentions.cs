using System;
using Merge.Board;

namespace Merge
{
    public static class Extentions
    {
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if(val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static bool IsInvalid(this CellCoordinates coords)
        {
            return SessionConstants.InvalidCoords == coords;
        }
    }
    
    
}