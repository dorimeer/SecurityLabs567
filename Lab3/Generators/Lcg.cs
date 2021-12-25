using System;
using System.Numerics;

namespace Lab3.Generators
{
    public class Lcg : IGenerator
    {
        private int _seed;
        private int _a;
        private int _c;
        private int _m;

        public Lcg(int seed, int a, int c, int m)
        {
            _seed = seed;
            _a = a;
            _c = c;
            _m = m;
        }

        public static Lcg GetSolvedLcg(int v1, int v2, int v3)
        {
            var num = 0;
            while (v2 - v3 - num * (v1 - v2) % int.MaxValue != 0)
            {
                num++;
            }

            var c = v2 - num * v1;
            return new Lcg(v3, num, c, Int32.MaxValue);
        }

        public int Next()
        {
            _seed = (_a * _seed + _c) % _m;
            return _seed;
        }
    }
}