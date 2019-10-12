using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Patient_Systems.Models
{
    public class Results
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public string Medical_Test { get; set; }

        [ForeignKey("patient_data")]
        public int Patient_ID { get; set; }

        public string Check { get; set; }

        public string Notes { get; set; }
        public string The_Type_Of_Disease { get; set; }
        public virtual Patient_Data patient_data { get; set; }

    }
}