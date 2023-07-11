using System.Runtime.InteropServices.JavaScript;

namespace Airline_reservation_systems.Models;

public class Ticket
{
    public string From_to  { get; set; }
    public Orindiqlar Orindiq { get;set; }
    public Guid codeNumber { get; set; }
    public DateTime uchishvaqti { get; set; }
    
}