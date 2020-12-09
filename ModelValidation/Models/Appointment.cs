using ModelValidation.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ModelValidation.Models
{
    public class Appointment
    {
        //validation is applied to all methods
        [Required]
        [StringLength(10, MinimumLength =3)]
        [Display(Name = "Client")]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Then date is obligatory")]
        //[AssertThat("Date > Now()")] - expressive annotations package


        //used for remote validation, client-side
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }
 
        
        //[Range(typeof(bool), "true", "true", ErrorMessage ="The box must be ticked")]
        //add custom validation attribute
        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }

    }
}