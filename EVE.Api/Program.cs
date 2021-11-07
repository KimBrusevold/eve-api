using System;
using System.Net.Http;
using System.Web;

namespace EVE.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /// https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-5.0
            var client = new HttpClient() // This will be entry for http calls. Will need to create a wrapper at some point
            {
                BaseAddress = new Uri("http://www.nrk.no"),//If many calls are towards the same url. e.g. someaddress.com/api and the difference is after /api
            };
        }
    }
}
