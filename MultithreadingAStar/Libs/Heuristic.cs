using System;
namespace MultiThreadingAStar
{
    public enum HeuristicMode
    {
        EUCLIDEAN
    };

    public class Heuristic
    {
        public static float Euclidean(int iDx, int iDy)
        {
            float tFdx = (float)iDx;
            float tFdy = (float)iDy;
            return (float)Math.Sqrt((double)(tFdx * tFdx + tFdy * tFdy));
        }

       
    }
}
