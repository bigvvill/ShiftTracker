using ShiftTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Ui
{
    public class GetUserInput
    {
        ApiController apiController = new();

        public void MainMenu()
        {
            Console.Clear();

            Console.WriteLine("Welcome to Shift Tracker!");
            Console.WriteLine("\nThis app helps you track the time you work and the money you make!");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("\n1 - Enter Times for a Shift");
            Console.WriteLine("2 - Display Shifts");
            Console.WriteLine("3 - Calculate Weekly Totals");
            Console.WriteLine("0 - Quit");

            string menuSelection = Console.ReadLine();

            switch (menuSelection)
            {
                case "0":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                case "1":
                    TimeEntry();
                    break;
                case "2":
                    apiController.GetShiftsAsync();
                    Console.ReadLine();
                    break;
                //case "3":
                //    apiController.GetTopics("classes");
                //    break;
                default:
                    Console.WriteLine("Please make a valid choice, 0-3!\nPress Enter...");
                    Console.ReadLine();
                    MainMenu();
                    break;
            }
        }

        public void TimeEntry()
        {
            Console.Clear();

            Console.WriteLine("Time Entry");
            Console.WriteLine("\nEnter start date in yyyy-mm-dd format (press Enter to use today as default or 0 to return to Menu):");
            string startDate = Console.ReadLine();

            if (startDate == "0")
            {
                MainMenu();
            }
            else if (startDate == "")
            {
                startDate = DateOnly.FromDateTime(DateTime.Now).ToString();
                Console.WriteLine(startDate);
            }

            // TODO : Validate

            Console.WriteLine("\nEnter start time in hh:mm:ss format (press Enter to use current time as default or 0 to return to Menu):");
            string startTime = Console.ReadLine();

            if (startTime == "0")
            {
                MainMenu();
            }
            else if (startTime == "")
            {
                startTime = TimeOnly.FromDateTime(DateTime.Now).ToString();
                TimeOnly startTimeOnly = TimeOnly.Parse(startTime);
                TimeSpan startTimeSpan = startTimeOnly.ToTimeSpan();
                Console.WriteLine(startTimeSpan);
            }

            // TODO : Validate

            string startTimeString = $"{startDate} {startTime}";
            DateTime shiftStart = DateTime.Parse(startTimeString);
            string sqlShiftStart = shiftStart.ToString("yyyy-MM-ddTHH:mm:ss");
            //Console.WriteLine(sqlShiftStart);            

            Console.WriteLine("\nEnter end date in yyyy-mm-dd format (press Enter to use today as default or 0 to return to Menu):");
            string endDate = Console.ReadLine();

            if (endDate == "0")
            {
                MainMenu();
            }
            else if (endDate == "")
            {
                endDate = DateOnly.FromDateTime(DateTime.Now).ToString();
                Console.WriteLine(endDate);
            }

            // TODO : Validate

            Console.WriteLine("\nEnter end time in hh:mm:ss format (press Enter to use current time as default or 0 to return to Menu):");
            string endTime = Console.ReadLine();

            if (endTime == "0")
            {
                MainMenu();
            }
            else if (endTime == "")
            {
                endTime = TimeOnly.FromDateTime(DateTime.Now).ToString();
                TimeOnly endTimeOnly = TimeOnly.Parse(endTime);
                TimeSpan endTimeSpan = endTimeOnly.ToTimeSpan();
                Console.WriteLine(endTimeSpan);
            }

            // TODO : Validate

            string endTimeString = $"{endDate} {endTime}";
            DateTime shiftEnd = DateTime.Parse(endTimeString);
            string sqlShiftEnd = shiftEnd.ToString("yyyy-MM-ddTHH:mm:ss");
            //Console.WriteLine(sqlShiftEnd);

            Console.WriteLine("\nEnter hourly rate in dd.cc format or 0 to return to Menu:");
            string hourlyRate = Console.ReadLine();

            if (hourlyRate == "0")
            {
                MainMenu();
            }

            // TODO : Validate

            decimal sqlHourlyRate = decimal.Parse(hourlyRate);

            Console.WriteLine("\nEnter location or 0 to return to Menu:");
            string location = Console.ReadLine();

            if (location == "0")
            {
                MainMenu();
            }

            // TODO : Validate

            Shift currentShift = new Shift();
            currentShift.Start = shiftStart;
            currentShift.End= shiftEnd;
            currentShift.Pay = sqlHourlyRate;
            currentShift.Location = location;

            ApiController apiController = new();
            CancellationToken cancellationToken= new CancellationToken();
            ApiController.PostBasicAsync(currentShift, cancellationToken);
        }
    }
}
