using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Patient_Systems.Models
{
    public partial class Patient_Data
    {
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}