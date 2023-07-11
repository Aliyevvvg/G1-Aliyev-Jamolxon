namespace Airline_reservation_systems.Models;

public class Message
{
    
                public long message_id { get; set; }
                public From from { get; set; }
                public Chat chat { get; set; }
                public long date { get; set; }
        
                public string text { get; set; }
    
}