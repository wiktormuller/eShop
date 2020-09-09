﻿using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static async Task Main()
        {
            //Discover endpoints from metadata
            var client = new HttpClient();

            var discovery = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if(discovery.IsError)
            {
                Console.WriteLine(discovery.Error);
                return;
            }

            //Request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            { 
                Address = discovery.TokenEndpoint,

                ClientId = "client",
                ClientSecret = "password",
                Scope = "api1"
            });

            if(tokenResponse.IsError)
            {
                Console.Write(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);

            //Call API
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("https://localhost:6001/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
