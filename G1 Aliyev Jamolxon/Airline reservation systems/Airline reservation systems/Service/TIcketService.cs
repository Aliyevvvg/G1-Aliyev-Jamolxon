using Airline_reservation_systems.Models;

namespace Airline_reservation_systems.Service;

public class TIcketService
{
    private UserService _userService;
    private User User;
    public TIcketService(UserService userService,User user)
    {
        _userService = userService;
        User = user;
    }
    private List<Ticket> Tickets = new List<Ticket>();
    public void GetTicket()
    {
      var user=  _userService.FindUser(User.Phonenumber, User.Password);
      
    }
}