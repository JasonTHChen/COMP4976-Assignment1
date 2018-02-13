using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmycDataLib.Models.BoatClub
{
    public class Boat
    {
        public int BoatId { get; set; }

        [Required]
        [Display(Name = "Boat Name")]
        public string BoatName { get; set; }
        public byte[] Picture { get; set; }

        [Required]
        [Display(Name = "Length In Feet")]
        public double LengthInFeet { get; set; }
        public string Make { get; set; }
        [Required]
        public DateTime Year { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
