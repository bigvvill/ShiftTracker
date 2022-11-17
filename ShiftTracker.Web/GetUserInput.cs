using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Web
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
                //case "1":
                //    apiController.GetTopics("backgrounds");
                //    break;
                //case "2":
                //    apiController.GetTopics("races");
                //    break;
                //case "3":
                //    apiController.GetTopics("classes");
                //    break;
                default:
                    Console.WriteLine("Please make a valid choice, 0-3! Press Enter...");
                    Console.ReadLine();
                    MainMenu();
                    break;
            }
        }
    }
}
