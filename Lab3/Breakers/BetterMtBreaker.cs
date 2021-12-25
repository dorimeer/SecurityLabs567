using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Lab3.Generators;

namespace Lab3.Breakers
{
    public class BetterMtBreaker
    {
        private const int AccountId = 6565757;

        public static async Task Break()
        {
            var generator = await GetVictory();
            var client = new Client();
            var state = await client.MakeBet(AccountId, generator!.Next(), 1, PlayMode.BetterMt);
            Console.WriteLine(state.message);
        }

        private static async Task<IGenerator?> GetVictory()
        {
            var mtGenerator = new MtGenerator(0);
            var client = new Client();
            for (var i = 0; i < 624; i++)
            {
                var result = await client.MakeBet(AccountId, 1, 1, PlayMode.BetterMt);
                mtGenerator.UntemperByIndex(i,(uint) result.realNumber);
            }
            return mtGenerator;
        }
    }
}