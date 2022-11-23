using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Ui
{
    internal class Validation
    {
        public static bool IsDateValid(string? stringInput)
        {
            string[] dateFormat = { "yyyy-mm-dd" };


            if (string.IsNullOrEmpty(stringInput) || stringInput.Length > 10)
            {
                return false;
            }

            foreach (char c in stringInput)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }

            return true;
        }
    }
}
