using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShiftTracker.Ui
{
    public record class ShiftRepository
        (
            [property: JsonPropertyName("shiftId")] int ShiftId,
            [property: JsonPropertyName("start")] DateTime Start,
            [property: JsonPropertyName("end")] DateTime End,
            [property: JsonPropertyName("pay")] decimal Pay,
            [property: JsonPropertyName("minutes")] decimal Minutes,
            [property: JsonPropertyName("location")] string Location);   
        }
