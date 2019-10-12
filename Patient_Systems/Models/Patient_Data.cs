using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Patient_Systems.Models
{
    public partial class Patient_Data
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Please enter name"), MaxLength(40)]
        public string Full_Name { get; set; }

        [Required(ErrorMessage = "Please enter Address"), MaxLength(20)]
        public string Address { get; set; }

        public string Age { get; set; }

        public string Gender { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Phone Number")]
        public string Mobile { get; set; }

        public string Image { get; set; }

        public virtual ICollection<Results> results { get; set; }
    }
}