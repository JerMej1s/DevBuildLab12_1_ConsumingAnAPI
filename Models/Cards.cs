using System.Collections.Generic;

namespace Lab12_1_ConsumingAnAPI.Models
{
    public class DeckResponse
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public bool shuffled { get; set; }
        public int remaining { get; set; }
        public List<Card> cards { get; set; }
    }

    public class Card
    {
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }
    }
}
