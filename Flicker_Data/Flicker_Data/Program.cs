using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Flicker_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string lat;
            string lng;
            string radius;
            Console.WriteLine("Latitiude:");
            lat = Console.ReadLine();
            Console.WriteLine("Longitude");
            lng = Console.ReadLine();
            Console.WriteLine("Radius");
            radius = Console.ReadLine();
            string flickerapikey = "117e2581bc16e98e5b7e75bc0f171041";
            
            string license = "0,1,2,3,4,5,6,7,8";
            license.Replace(",", "%2C");
            string url = "https://api.flickr.com/services/rest/" +
                 "?method=flickr.photos.search" +
                 "&license={0}" +
                 "&api_key={1}" +
                // "&text=all" +
                 "&lat={2}" +
                 "&lon={3}" +
                 "&radius={4}" +
                 "&format=json" +
                 "&nojsoncallback=1";
                 //"&auth_token=72157683764343283-6bf95ab827f329f3";
                 //"&api_sig=fbdb1d4bb524c4f1e182f43dd953e678";
            var baseurl = string.Format(url, license, flickerapikey, lat, lng,radius);
           /*   WebClient webClient = new WebClient();
                webClient.Headers.Add("Authorization", personal_OAuthKey);*/

            // Create a WebClient
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Authorization", "Bearer 2NEWI72RJPV4KP2G64V3");
                // Send request to an address and get respose
                var response = webClient.DownloadString(baseurl);
                Console.WriteLine(response);
                
               /* var a = webClient.ResponseHeaders;

                string json = response;
                var capacity = JObject.Parse(json)["a"].Select(v => (int)v["a"]).ToList();
                for (int i = 0; i < capacity.Count; i++)
                {
                    Console.WriteLine(capacity[i]);
                }*/
                Console.ReadKey();
            }
        }
    }
}
