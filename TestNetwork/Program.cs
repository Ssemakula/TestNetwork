using System;
using System.Net.NetworkInformation;

namespace TestNetwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in interfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    Console.WriteLine($"Interface Name: {networkInterface.Name}");
                    Console.WriteLine($"Interface Description: {networkInterface.Description}");
                    Console.WriteLine($"Network Type: {networkInterface.NetworkInterfaceType}");
                    Console.WriteLine($"Is Connected: {networkInterface.OperationalStatus}");
                    Console.WriteLine($"IP Addresses:");

                    foreach (UnicastIPAddressInformation ip in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        Console.WriteLine($"   {ip.Address}");
                    }

                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
