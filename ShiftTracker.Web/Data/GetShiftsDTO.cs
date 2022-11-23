using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Ui.Data
{
    internal class GetShiftsDTO
    {        
        public int ShiftId { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }
        
        public decimal Pay { get; set; }
       
        public decimal Minutes { get; set; }
 
        public string Location { get; set; }

        public virtual List<GetShiftsDTO>? ShiftList { get; set; }
    }
}
