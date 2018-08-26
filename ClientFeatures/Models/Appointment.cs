using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClientFeatures.Models
{
    public class Appointment
    {
        [Required]
        public string ClinetName { get; set; }

        public bool TermsAccepted { get; set; }
    }
}