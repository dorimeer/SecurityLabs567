using System;
using System.Threading.Tasks;
using System.Xml.Schema;
using Lab3.Breakers;
using Lab3.Generators;

namespace Lab3
{
    public static class Program
    {
        public static async Task Main()
        {
            await LcgBreaker.Break();
            await MtBreaker.Break();
            await BetterMtBreaker.Break();
        }
    }
}