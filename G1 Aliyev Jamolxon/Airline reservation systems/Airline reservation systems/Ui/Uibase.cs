using Airline_reservation_systems.Models;
using Airline_reservation_systems.Service;

namespace Airline_reservation_systems.Ui;

public class Uibase

{
    private Bot_Server _botServer=new Bot_Server(_userService);
    private static UserService _userService=new UserService();
    private static User user;
    public Userview Userview =new Userview(user,_userService);
    
  
    public async Task Start()
    {
       var user1=await _botServer.HandleUpdate();
       user = user1;
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