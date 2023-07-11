using Airline_reservation_systems.Service;

namespace Airline_reservation_systems.Models;

public class Rootupdate
{
    public class RootUpdate
    {
        public bool ok { get; set; }
        public List<MessageUpdate> result { get; set; }
    }
}