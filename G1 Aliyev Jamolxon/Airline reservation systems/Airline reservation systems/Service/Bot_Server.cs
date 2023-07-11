using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using Airline_reservation_systems.Models;

namespace Airline_reservation_systems.Service;

public class Bot_Server
{
    private static UserService _userService;

    public Bot_Server(UserService userService)
    {
        _userService = userService;
    }
 
    
    
    static async Task<List<MessageUpdate>> GetUpdates(long offset)
    {
        List<MessageUpdate> updates=new List<MessageUpdate>()
        {
        };
        HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri($"https://api.telegram.org/bot6386849505:AAERv6-ASfbHptbJGtUmBY-uu7WIybp08EI/")
        };
        try
        {
            var result = await httpClient.GetAsync($"getUpdates?allowed_updates=message&offset={offset}");
            var updateContent = await result.Content.ReadAsStringAsync();
            updates = JsonSerializer.Deserialize<Rootupdate.RootUpdate>(updateContent).result;
        }
        catch (Exception e)
        {
            return new List<MessageUpdate>();

        }
       return updates;
    }
   
    static async Task Send_Message(long chatId, string text)
    {
        HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri($"https://api.telegram.org/bot6386849505:AAERv6-ASfbHptbJGtUmBY-uu7WIybp08EI/")
        };
        var data = new SendMessagePost()
        {
            chat_id = chatId,
            text= text,
            parse_mode = "HTML"
        };
        var sendMessageDataJsonContent = JsonSerializer.Serialize(data);

        var postResult = await httpClient.PostAsync("sendMessage",
            new StringContent(sendMessageDataJsonContent, Encoding.Default, "application/json"));

        var postResultContent = await postResult.Content.ReadAsStringAsync();
    }
    
    static async Task<User> HandleUpdate()
    {tuda:
          MessageUpdate messageUpdates=await GetUpadatechat();
          
        try
        { 
            var chatId = messageUpdates.message.message_id;
            var updateText = messageUpdates.message.text;
            if (updateText == "start")
                await Send_Message(chatId, "Hello I`m bot of G1 Airlines,\nTo Forward Your Room Login or Registration");
            messageUpdates = await GetUpadatechat();
            if (messageUpdates.message.text == "Registration")
            {
                await Send_Message(messageUpdates.message.chat.id, "Enter name");
                messageUpdates =await GetUpadatechat();
                var Username = messageUpdates.message.text;
                await Send_Message(messageUpdates.message.chat.id, "Enter Phone number");
                messageUpdates = await GetUpadatechat();
                var Userphonenumber = messageUpdates.message.text;
                await Send_Message(messageUpdates.message.chat.id, "Enter password");
                messageUpdates = await GetUpadatechat();
                var Userpassword = messageUpdates.message.text;
                messageUpdates = await GetUpadatechat();
                User user = new User()
                {
                    Name = Username,
                    Password = Userpassword,
                    Phonenumber = Userphonenumber,

                };
                await Send_Message(messageUpdates.message.chat.id, "Succesfuly Authorizing");
                _userService.Users.Add(user);
                return user;
            }
            else if (messageUpdates.message.text=="Login")
            {
                await Send_Message(messageUpdates.message.chat.id, "Enter Phone number");
                messageUpdates = await GetUpadatechat();
                var Userphonenumber = messageUpdates.message.text;
                await Send_Message(messageUpdates.message.chat.id, "Enter password");
                messageUpdates = await GetUpadatechat();
                var Userpassword = messageUpdates.message.text;
                messageUpdates = await GetUpadatechat();
                   var user=  _userService.FindUser(Userphonenumber, Userpassword);
                    await Send_Message(messageUpdates.message.chat.id, "Succesfuly Login");
                    if(user!=null)
                        return user;
                
                else
                {
                    await Send_Message(messageUpdates.message.chat.id, "What is wrong please try again");
                    goto tuda;
                }

            }
               // await Send_Message(chatId, updateText);
    
    
        }
        catch (Exception e)
        {
            
            await Send_Message(messageUpdates.message.chat.id, "What is wrong please try again");
            goto tuda;
        }

        return new User();
    }

    static async Task<MessageUpdate> GetUpadatechat()
    {
        MessageUpdate messageUpdate;
        var messageUpdates1= await GetUpdates(-1);
        messageUpdate = messageUpdates1[0];
        return messageUpdate;
    }
}






