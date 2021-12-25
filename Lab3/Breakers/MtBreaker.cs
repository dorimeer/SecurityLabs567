using System;
using System.Threading.Tasks;
using Lab3.Generators;

namespace Lab3.Breakers
{
    public static class MtBreaker
    {
        private const int AccountId = 6565757;
        private const long SecondsInHour = 3600;

        public static async Task Break()
        {
            var generator = await GetVictory();
            var client = new Client();
            var state = await client.MakeBet(AccountId, generator!.Next(), 1, PlayMode.Mt);
            Console.WriteLine(state.message);
        }

        private static async Task<IGenerator?> GetVictory()
        {
            var client = new Client();
            var state = await client.MakeBet(AccountId, 1, 1, PlayMode.Mt);
            var dt1970 = new DateTime(1970, 1, 1);
            var time = state.account.DeletionTime;
            var timeSpan = time - dt1970;
            var initTime = timeSpan.TotalMilliseconds / 1000 - SecondsInHour - 40;

            var casinoValue = state.realNumber;

            for (var i = 0; i < 80; i++)
            {
                IGenerator? generator = new MtGenerator((int)(initTime + i));
                for (int j = 0; j < 700; j++) {
                    var generated = generator.Next();
                    if ((uint)generated == casinoValue) {
                        return generator;
                    }
                }
            }
            return null;
        }
    }
}