using Airline_reservation_systems.Domain.Enums;
using Airline_reservation_systems.Models;
using Airline_reservation_systems.Service.Interfaces;

namespace Airline_reservation_systems.Service;

public class UserService:IUserService
{
 private int i = 0;
 public List<User> Users=new List<User>();

 public List<User> GetAllUsers()
 {
  return Users;
 }

 public User FindUser(string phonenumber, string password)
 {
  return Users.Find(x => x.Phonenumber == phonenumber && x.Password == password);
 }

 public bool FindUserforBot(string phonenumber, string password)
 {
  var user = Users.Find(x => x.Phonenumber == phonenumber && x.Password == password);
   if(user!=null)
   {
   return true;
   }
   return false;
 }



 public void BuyTicecket(string phonenumber, string password,string from_to)
 {
  var user = FindUser(phonenumber, password);
  user._ticket.Add(new Ticket
  {
   codeNumber = new Guid(),
   From_to = from_to,
   Orindiq = new Orindiqlar
   {
    Orindiqnomeri = i++,
    OrindiqStatusi = OrindiqSttusi.OrindiqStatusi.Belgilangan,
    
   },
   uchishvaqti = DateTime.Now
  });
 }
}