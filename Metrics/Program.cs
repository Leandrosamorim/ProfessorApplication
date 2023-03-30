// See https://aka.ms/new-console-template for more information
using var server = new Prometheus.KestrelMetricServer(port: 1234);
server.Start();

Console.WriteLine("Open http://localhost:1234/metrics in a web browser.");
Console.WriteLine("Press enter to exit.");
Console.ReadLine();