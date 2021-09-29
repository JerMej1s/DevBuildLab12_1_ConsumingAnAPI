using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab12_1_ConsumingAnAPI.Models
{
    public class DAL
    {
        private static HttpClient client = null;
        private static HttpClient GetHttpClient()
        {
            // Build a singleton object of type HttpClient

            if (client is null)
            {
                // Client instance hasn't been created yet. Make it and initialize it.
                client = new HttpClient();
                client.BaseAddress = new Uri("https://deckofcardsapi.com");
            }

            return client;
        }

        public async static Task<string> GetNewDeck()
        {
            var connection = await GetHttpClient().GetAsync("/api/deck/new/shuffle/?deck_count=1");
            DeckResponse response = await connection.Content.ReadAsAsync<DeckResponse>();
            return response.deck_id;
        }

        public async static Task<DeckResponse> GetCards(string deck_id, int draw_count)
        {
            var connection = await GetHttpClient().GetAsync($"https://deckofcardsapi.com/api/deck/{deck_id}/draw/?count={draw_count}");
            DeckResponse response = await connection.Content.ReadAsAsync<DeckResponse>();
            return response;
        }
    }
}
