using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using RestSharp;
using ShiftTracker.Entities;
using ShiftTracker.Ui.Data;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

namespace ShiftTracker.Ui;

public class ApiController
{
    public async Task GetShiftsAsync()
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();            

        await ProcessRepositoriesAsync(client);

        static async Task ProcessRepositoriesAsync(HttpClient client)
        {
            await using Stream stream = await client.GetStreamAsync("https://localhost:7104/api/Shifts");

            var repositories = await System.Text.Json.JsonSerializer.DeserializeAsync<List<ShiftRepository>>(stream);

            List<Shift> shifts = new List<Shift>();

            foreach (var repo in repositories)
            {
                Shift currentShift = new();

                currentShift.ShiftId = repo.ShiftId;
                currentShift.Start = repo.Start;
                currentShift.End = repo.End;
                currentShift.Pay = repo.Pay;
                currentShift.Minutes = repo.Minutes;
                currentShift.Location = repo.Location;
                shifts.Add(currentShift);                   
            }

            TableFormat.ShowTable<Shift>(shifts, "Shifts");
        }
    }

    public async Task PostShiftsAsync(Shift createNewShift)
    {
        using HttpClient client = new();
        //client.DefaultRequestHeaders.Accept.Clear();

        string url = "https://localhost:7104/api/Shifts";

        var newShift = createNewShift;

        var jsonContent = JsonConvert.SerializeObject(newShift);
        
        var content = new StringContent(jsonContent);


        try
        {
            var shifts = await client.PostAsync(url, content);
            Console.ReadLine();
            var stream = await shifts.Content.ReadAsStreamAsync();
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }
        
        
        //var shifts = await client.PostAsync(url, content);
        //var stream = await shifts.Content.ReadAsStreamAsync();
    }


    public async void Post(Shift currentShift)
    {
        var client = new RestClient("https://localhost:4071");
        var postShift = new RestRequest().AddJsonBody(currentShift);
        var postShiftResponse = await client.PostAsync<Shift>(postShift);
    }

    public static async Task PostBasicAsync(object content, CancellationToken cancellationToken)
    {
        using (var client = new HttpClient())
        using (var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7104/api/Shifts"))
        {
            var json = JsonConvert.SerializeObject(content);
            using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                request.Content = stringContent;

                using (var response = await client
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }
    }
}