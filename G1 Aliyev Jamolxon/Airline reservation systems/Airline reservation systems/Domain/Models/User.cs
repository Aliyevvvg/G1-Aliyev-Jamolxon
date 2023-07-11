namespace Airline_reservation_systems.Models;

public class User
{
    public string Name { get; set; }
    public string Phonenumber { get; set; }
    public string Password { get; set; }
    public List<Ticket> _ticket { get; set; }
}