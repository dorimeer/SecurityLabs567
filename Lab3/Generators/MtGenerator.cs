using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Lab3.Generators
{
    public class MtGenerator : IGenerator
    {
        private const int BytesPoolSize = 624;
        private const int Period = 397;
        private static readonly uint[] Mag01 = { 0, 0x9908b0df };
        
        private int[] Mt;
        private int Mti;

        public MtGenerator(int seed)
        {
            Mt = new int[BytesPoolSize];
            SetSeed(seed);
        }
        private void SetSeed(int seed)
        {
            long longMt = seed;
            Mt[0] = (int)longMt;
            for (Mti = 1; Mti < BytesPoolSize; ++Mti)
            {
                longMt = (1812433253 * (longMt ^ (longMt >> 30)) + Mti) & 0xffffffff;
                Mt[Mti]= (int) longMt;
            }
        }

        public void UntemperByIndex(int index, uint y)
        {
            y ^= y >> 18;
            y ^= (y << 15) & 0xEFC60000;
            const uint mask = 0x9d2c5680;
            for (var i = 0; i < 7; i++) 
            {
                y ^= (y << 7) & mask;
            }
            
            y ^= y >> 11;
            y ^= y >> 11;
            y ^= y >> 11;

            Mt[index] = (int)y;
        }
        
        public int Next()
        {
            long y;

            if (Mti >= BytesPoolSize) {
                long mtNext = Mt[0];
                for (int k = 0; k < BytesPoolSize - Period; ++k) {
                    long mtCurr = mtNext;
                    mtNext = Mt[k + 1];
                    y = (mtCurr & 0x80000000) | (mtNext & 0x7fffffff);
                    Mt[k] = (int)(Mt[k + Period] ^ (int)((uint)y >> 1) ^ Mag01[y & 0x1]);
                }
                for (int k = BytesPoolSize - Period; k < BytesPoolSize - 1; ++k) {
                    long mtCurr = mtNext;
                    mtNext = Mt[k + 1];
                    y = (mtCurr & 0x80000000) | (mtNext & 0x7fffffff);
                    Mt[k] = (int)(Mt[k + (Period - BytesPoolSize)] ^ (int)((uint)y >> 1) ^ Mag01[y & 0x1]);
                }
                y = (mtNext & 0x80000000) | (Mt[0] & 0x7fffffff);
                Mt[BytesPoolSize - 1] = (int)(Mt[Period - 1] ^ (int)((uint)y >> 1) ^ Mag01[y & 0x1]);

                Mti = 0;
            }

            y = Mt[Mti++];

            y ^= (int)((uint)y >> 11);
            y ^= (y <<  7) & 0x9d2c5680;
            y ^= (y <<  15) & 0xefc60000;
            y ^= (int)((uint)y >> 18);

            return (int)y;
        }
    }
}