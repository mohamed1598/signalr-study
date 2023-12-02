using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
Console.WriteLine("Background Changer App!");

var connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7164/hubs/color")
    .WithAutomaticReconnect()
    .Build();

connection.On<string>("TriggerColor", (color) =>
{
    switch (color)
    {
        case "Yellow": Console.BackgroundColor = ConsoleColor.Yellow; break;
        case "Blue": Console.BackgroundColor = ConsoleColor.Blue; break;
        case "Orange": Console.BackgroundColor = ConsoleColor.Red; break;
        default: Console.BackgroundColor = ConsoleColor.Black; break;
    }

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Changed color to {color}");
});

await connection.StartAsync();

Console.WriteLine("[JY]Join Yellow | [JB]Join Blue | [JO]Join Orange] |[Y]Yellow | [B]Blue | [O]Orange] | E[x]it");
var keepGoing = true;
do
{
    var key = Console.ReadLine();
    Console.WriteLine();
    switch (key)
    {
        case "JY":
            await connection.SendAsync("JoinGroup", "Yellow");
            break;
        case "JB":
            await connection.SendAsync("JoinGroup", "Blue");
            break;
        case "JO":
            await connection.SendAsync("JoinGroup", "Orange");
            break;
        case "Y":
            await connection.SendAsync("TriggerGroup", "Yellow");
            break;
        case "B":
            await connection.SendAsync("TriggerGroup", "Blue");
            break;
        case "O":
            await connection.SendAsync("TriggerGroup", "Orange");
            break;
        case "X":
            keepGoing = false;
            break;
        default: Console.WriteLine("No..."); break;
    }
} while (keepGoing);

await connection.StopAsync();