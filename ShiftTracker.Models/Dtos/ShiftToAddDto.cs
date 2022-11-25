using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.Models.Dtos;

public class ShiftToAddDto
{
    [Required]
    public DateTime Start { get; set; }
    [Required]
    public DateTime End { get; set; }
    [Required]
    [Column(TypeName = "decimal(19,4)")]
    public decimal Pay { get; set; }
    [Required]
    [Column(TypeName = "decimal(19,4)")]
    public decimal Minutes { get; set; }
    [Required]
    public string Location { get; set; }
}
