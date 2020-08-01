using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Afspraak
    {
        [Required]
        public int AfspraakID { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string KlantNaam { get; set; }
        
        [Required]
        [StringLength(10, ErrorMessage = "Telefoon nummer moet 10 nummers bevatten.")]
        public string KlantTelnr { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AfspraakDatum { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan AfspraakTijd { get; set; }
    }
}
