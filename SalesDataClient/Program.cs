//Create a channel for your gRPC Service
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService;

var channel = GrpcChannel.ForAddress("https://localhost:7063");

//Create SalesService Client to open a connection
var client = new SalesService.SalesServiceClient(channel);

//Invoke the method
using var call = client.GetSalesData(new Request { Filters = "" }, deadline: DateTime.UtcNow.AddSeconds(15));

int Count = 0;

//Get response stream
await foreach (var each in call.ResponseStream.ReadAllAsync())
{
    Console.WriteLine(String.Format("New Order received from {0}-{1} / Order ID = {2} / Unit Price = {3} / Ship Date = {4}", each.Country, each.Region, each.OrderID, each.UnitPrice, each.ShipDate));

    Count++;
}

Console.WriteLine("Stream ended, total records: " + Count.ToString());

Console.Read();

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
