﻿using ModelValidation.Infrastructure;
using System;
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
        
        //[Range(typeof(bool), "true", "true", ErrorMessage ="The box must be ticked")]
        //add custom validation attribute
        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }

    }
}