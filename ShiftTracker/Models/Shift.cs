using System.ComponentModel.DataAnnotations.Schema;

namespace ShiftTracker.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [Column(TypeName = "decimal(19,4)")]
        public decimal Pay { get; set; }

        [Column(TypeName = "decimal(19,4)")]
        public decimal Minutes { get; set; }

        public string Location { get; set; }
    }
}
