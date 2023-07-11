using Airline_reservation_systems.Models;

namespace Airline_reservation_systems.Service.Interfaces;

public interface IUserService
{
    public List<User> GetAllUsers();
    public User FindUser(string phonenumber, string password);
    public bool FindUserforBot(string phonenumber, string password);
    public void BuyTicecket(string phonenumber, string password,string from_to);
}