using System;
using System.Threading.Tasks;
using Lab3.Generators;

namespace Lab3.Breakers
{
    public static class LcgBreaker
    {
        public static async Task Break()
        {
            var client = new Client();
            var account = await client.CreateAccountAsync(6565757);
            var a1 = await client.MakeBet(6565757, 1, 1, PlayMode.Lcg);
            var a2 = await client.MakeBet(6565757, 1, 1, PlayMode.Lcg);
            var a3 = await client.MakeBet(6565757, 1, 1, PlayMode.Lcg);
            var solvedLcg = Lcg.GetSolvedLcg((int)a1.realNumber, (int)a2.realNumber, (int)a3.realNumber);
            var next = solvedLcg.Next();
            var result = await client.MakeBet(6565757, next, 1, PlayMode.Lcg);
            Console.WriteLine(result.message);
        }
    }
}