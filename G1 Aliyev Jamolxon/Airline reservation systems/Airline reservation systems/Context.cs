using Airline_reservation_systems.Models;
using Airline_reservation_systems.Service;
using Airline_reservation_systems.Ui;

namespace Airline_reservation_systems;

public static class Context
{
    private static Uibase _uibase = new Uibase();

    public static void Start()
    {
        _uibase.Start();
    }
}