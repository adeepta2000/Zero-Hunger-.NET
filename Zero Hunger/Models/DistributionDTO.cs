using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class DistributionDTO
    {
        public int Did { get; set; }
        [Required]
        public int Employee_Id { get; set; }
        [Required]
        public int Restaurent_Id { get; set; }
        [Required]
        public string Food_Item { get; set; }
        [Required]
        public string Max_Preservation_Time { get; set; }

    }
}