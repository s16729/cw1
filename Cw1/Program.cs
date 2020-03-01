using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //var newPerson = new Person { FirstName = "Damian"}";
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
