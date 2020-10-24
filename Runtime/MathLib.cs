namespace MathLib.Runtime
{
    public static class MathLib
    {
        public static int Modulus(int a, int n)
        {
            int r = a % n;
            return r < 0 ? r + n : r;
        }
    }
}