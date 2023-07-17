using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class RequestDTO
    {
  
        public int Cid { get; set; }
        [Required]
        public int Restaurent_Id { get; set; }
        [Required]
        public string Food_Item { get; set; }
        [Required]
        public string Max_Preservation_Time { get; set; }

    }
}