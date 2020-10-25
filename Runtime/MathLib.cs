using UnityEngine;

namespace MathLibs.Runtime
{
    public static class MathLib
    {
        public static int Modulus(int a, int n)
        {
            int r = a % n;
            return r < 0 ? r + n : r;
        }

        public static Vector3 GetRelativeDirection(Vector3 forward, Vector3 v)
        {
            var angle = GetRelativeAngle(forward, v);
            var direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0, Mathf.Sin(Mathf.Deg2Rad * angle));
            return direction;
        }

        public static float GetRelativeAngle(Vector3 forward, Vector3 v)
        {
            var angle = Vector3.SignedAngle(forward, v, Vector3.up);
            return angle;
        }
    }
}