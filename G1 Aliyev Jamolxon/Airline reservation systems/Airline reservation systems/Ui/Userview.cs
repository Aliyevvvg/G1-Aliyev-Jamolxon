using Airline_reservation_systems.Models;
using Airline_reservation_systems.Service;
using Airline_reservation_systems.Service.Interfaces;

namespace Airline_reservation_systems.Ui;

public class Userview
{
    private User user;
    private UserService _userService;
    public Userview(User user1,UserService userService)
    {
        user = user1;
        _userService = userService;
    }
  
    public void BuyTicket()
    {
        Console.WriteLine("qayerga uchmoqchisiz");
        string fromto = Console.ReadLine();
        _userService.BuyTicecket(user.Phonenumber,user.Password,fromto);
        
    }

    public void Ticketlarnikorish()
    {
        foreach (var ticket in user._ticket)
        {
            Console.WriteLine("Narxi: 230$ "+"Qayergaligi "+ticket.From_to+"Uchish vaqti "+ticket.uchishvaqti+" Orndiq nomeri"+ticket.Orindiq);
        }

        Console.ReadKey();
    }
    
}