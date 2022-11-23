using Microsoft.EntityFrameworkCore.Metadata.Internal;

using RestSharp;
using ShiftTracker.Models;
using ShiftTracker.Ui.Data;
using System.Text.Json;

namespace ShiftTracker.Ui
{
    internal class ApiController
    {
        internal async Task GetShiftsAsync()
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();            

            await ProcessRepositoriesAsync(client);

            static async Task ProcessRepositoriesAsync(HttpClient client)
            {
                await using Stream stream = await client.GetStreamAsync("https://localhost:7104/api/Shifts");

                var repositories = await JsonSerializer.DeserializeAsync<List<ShiftRepository>>(stream);

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



        internal async void Post(Shift currentShift)
        {
            var client = new RestClient("https://localhost:4071");
            var postShift = new RestRequest().AddJsonBody(currentShift);
            var postShiftResponse = await client.PostAsync<Shift>(postShift);
        }
    }
}