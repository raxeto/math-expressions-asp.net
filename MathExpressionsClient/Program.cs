using System.Net.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MathExpressionsClient;
using Microsoft.Extensions.Configuration;
using MathExpressionsClient.Responses;

internal class Program
{
    private static async Task Main(string[] args)
    {
        string[] availableCommands = new string[] { "evaluate", "validate", "errors" };

        var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

        var serviceSettings = new MathExpressionsServiceSettings();
        configuration.GetSection("MathExpressionsServiceSettings").Bind(serviceSettings);

        Console.WriteLine($"Service address: {serviceSettings.ServiceAddress}");

        while (true)
        { 
            Console.WriteLine("Enter command {0} or Enter to exit...", string.Join("|", availableCommands));

            string? command = Console.ReadLine();

            if (command == null || !availableCommands.Contains(command))
            {
                return;
            }

            MathExpressionServiceClient client = new MathExpressionServiceClient(serviceSettings.ServiceAddress);

            if (command == "evaluate" || command == "validate")
            {
                Console.WriteLine("Enter simple math expression: ");

                string? expression = Console.ReadLine();

                if (string.IsNullOrEmpty(expression))
                {
                    return;
                }

                string result;

                if (command == "evaluate")
                {
                    result = await client.SendPostEvaluate(expression);
                }
                else
                {
                    result = await client.SendPostValidate(expression);
                }

                Console.WriteLine(result);
            }
            else if (command == "errors")
            {
                ErrorJson[]? errors = await client.SendGetErrors();

                if (errors == null || errors.Length == 0)
                {
                    Console.WriteLine("There is no registred errors yet.");
                }
                else
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error);
                    }
                }
            }
        }
    }
}