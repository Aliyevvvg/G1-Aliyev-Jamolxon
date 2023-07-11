using System.Text.Json.Serialization;

namespace Airline_reservation_systems.Models;

public class SendMessagePost
{

        public long chat_id { get; set; }
    
        [JsonPropertyName("text")]
        public string text { get; set; }
    
        [JsonPropertyName("parse_mode")]
        public string parse_mode { get; set; }
    
}