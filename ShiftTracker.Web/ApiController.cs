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
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

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

                    //Console.WriteLine(repo.ShiftId);
                    //Console.WriteLine(repo.Start);
                    //Console.WriteLine(repo.End);
                    //Console.WriteLine(repo.Pay);
                    //Console.WriteLine(repo.Minutes);
                    //Console.WriteLine(repo.Location);
                    //Console.WriteLine();
                }

                TableFormat.ShowTable<Shift>(shifts, "Shifts");
            }

            //var client = new RestClient("https://localhost:4071");
            //var request = new RestRequest("/api/Shifts");
            //var response = client.ExecuteAsync(request);

            //List<GetShiftsDTO> shifts = new List<GetShiftsDTO>();

            //if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    string rawresponse = response.Result.Content;
            //    var serialize = JsonConvert.DeserializeObject<GetShiftsDTO>(rawresponse);

            //    shifts = serialize.ShiftList;

            //    TableFormat.ShowTable(shifts, "Shifts");

            //    Console.ReadLine();
            //}


        }



        internal async void Post(Shift currentShift)
        {
            var client = new RestClient("https://localhost:4071");
            var postShift = new RestRequest().AddJsonBody(currentShift);
            var postShiftResponse = await client.PostAsync<Shift>(postShift);
        }
    }
}