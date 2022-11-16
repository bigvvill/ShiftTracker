using ShiftTracker.Models;

namespace ShiftTracker.Services
{
    public class ShiftService
    {
        public Shift CalculateTime(Shift shift)
        {
            DateTime startShift = shift.Start;
            DateTime endShift = shift.End;
            TimeSpan calculatedTime = endShift - startShift;
            decimal hours = calculatedTime.Hours;
            decimal minutes = calculatedTime.Minutes;

            decimal calculatedMinutes = (hours * 60) + minutes;

            shift.Minutes= calculatedMinutes;
            shift.Pay = (calculatedMinutes / 60) * 25.50m;

            return shift;
        }
    }
}
