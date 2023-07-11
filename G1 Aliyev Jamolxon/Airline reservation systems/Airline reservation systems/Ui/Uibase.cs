using Airline_reservation_systems.Models;
using Airline_reservation_systems.Service;

namespace Airline_reservation_systems.Ui;

public class Uibase

{
    private Bot_Server _botServer;
    private static UserService _userService;
    private static User user;
    public Userview Userview ;
    public Uibase(User user1,UserService userService,Bot_Server bot)
    {
        _botServer = bot;
        user = user1;
        _userService = userService;
    }

    public void Start()
    {
        Console.WriteLine("1.Ticketlar royhatini korish");
        Console.WriteLine("Qolgan tugmalar Chiqish uchun yolak");
        int a =Int32.Parse(Console.ReadLine()); ;
        if (a == 1)
        {
            Userview.Ticketlarnikorish();
        }
        else
        {
            return;
        }
    }
}