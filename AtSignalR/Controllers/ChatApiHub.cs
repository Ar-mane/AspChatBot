using Microsoft.AspNetCore.SignalR;

namespace AtSignalR.Controllers;

public class ChatApiHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"{Context.ConnectionId} connected ");
        await base.OnConnectedAsync();
    }

    public async Task SendMessage(string user, string message)
    {
        Console.WriteLine($"{message} <== {user}");
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}