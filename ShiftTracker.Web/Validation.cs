using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Web
{
    internal class Validation
    {
        public static bool IsDateValid(string? stringInput)
        {
            string[] dateFormat = { "yyyy-mm-dd" };


            if (String.IsNullOrEmpty(stringInput) || stringInput.Length > 50)
            {
                return false;
            }

            foreach (char c in stringInput)
            {
                if (!Char.IsLetter(c) && c != ' ')
                    return false;
            }

            return true;
        }
    }
}
