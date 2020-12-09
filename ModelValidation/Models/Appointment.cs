﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class Appointment
    {
        //validation is applied to all methods
        [Required]
        [Display(Name = "Client")]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Then date is obligatory")]
        public DateTime Date { get; set; }
        public bool TermsAccepted { get; set; }

    }
}