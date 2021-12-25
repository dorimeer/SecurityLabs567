using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab3
{
    public class Account
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("money")]
        public int Money { get; set; }
        [JsonPropertyName("deletionTime")]
        public DateTime DeletionTime { get; set; }
    }

    public record BetResult(string message, Account account, long realNumber);

    public enum PlayMode
    {
        Lcg,
        Mt,
        BetterMt
    }
    public class Client
    {
        private const string BaseUrl = "http://95.217.177.249/casino";

        public async Task<Account> CreateAccountAsync(int accountId)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(BaseUrl + $"/createacc?id={accountId}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var deserializedMessage = JsonSerializer.Deserialize<Account>(responseContent);
            return deserializedMessage;
        }

        public async Task<BetResult> MakeBet(int id, long number, int bet, PlayMode playMode)
        {
            using var client = new HttpClient();
            var response = await client
                .GetAsync(BaseUrl + $"/play{playMode.ToString()}?id={id}&number={number}&bet={bet}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var deserializedMessage = JsonSerializer.Deserialize<BetResult>(responseContent);
            return deserializedMessage;
        }
    }
}