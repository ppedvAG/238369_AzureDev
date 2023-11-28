// See https://aka.ms/new-console-template for more information
using Azure.Storage.Queues;

Console.WriteLine("Hello, World!");


var conString = "DefaultEndpointsProtocol=https;AccountName=andresstorage2;AccountKey=Z4oxqwYcjL02W2/cQ//8ZhMHmqQTseFCBwBj6+F7GAQ6S5q+tIfOg88hTzkuHjatd8m8fUeB2Uzp+AStfdvJfw==;EndpointSuffix=core.windows.net";

var client = new QueueClient(conString, "msgs");

while (true)
{
    var msg = client.ReceiveMessage();
    if(msg.Value != null)
    {
        //var msgTxt = Convert.FromBase64String(msg.Value.Body.ToString());

        Console.WriteLine($"{msg.Value.Body} [{msg.Value.MessageId}]");

        client.DeleteMessage(msg.Value.MessageId, msg.Value.PopReceipt);

        Thread.Sleep(1000);
    }
}