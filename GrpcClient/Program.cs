using Grpc.Net.Client;
using GrpcService;

var channel = GrpcChannel.ForAddress("https://localhost:7063");

var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(new GrpcService.HelloRequest { Name = "gRPC" });

Console.WriteLine(string.Format("From Server: {0}", reply));

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
