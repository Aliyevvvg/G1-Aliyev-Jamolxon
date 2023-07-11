using Airline_reservation_systems.Domain.Enums;

namespace Airline_reservation_systems.Models;

public class AirLine
{
    public string Borish_manzil { get; set; }
    public int Oridiqlar { get; set; }
    public ParvozStatus.Status Parvoz_statusi { get; set; }
}