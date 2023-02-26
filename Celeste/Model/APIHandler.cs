using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{
    public class APIHandler
    {

        public static async Task SendMessageToApi(string message)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://example.com/api/message");

                // Create the request content with the message data
                var content = new StringContent(message, Encoding.UTF8, "application/json");

                // Send the request
                var response = await client.PostAsync(uri, content);

                // Check if the request was successful
                if (!response.IsSuccessStatusCode)
                {
                    // Handle the error
                    Console.WriteLine("Error sending message to API: " + response.StatusCode);
                }
            }
        }

    }

}
