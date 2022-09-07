using System.Net.Http.Headers;
using System.Net.Http.Json;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7230");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/User");
response.EnsureSuccessStatusCode();

if (response.IsSuccessStatusCode)
{
    var users = await response.Content.ReadFromJsonAsync<IEnumerable<UserObject>>();

    foreach (var item in users)
    {
        Console.WriteLine(item.FirstName);
    }
}
else
{
    Console.WriteLine("no result");
}

Console.ReadLine();