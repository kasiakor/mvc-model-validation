using ModelValidation.Models;
using System;
using System.Web.Mvc;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public ActionResult MakeBooking(Appointment appo)
        {

            if(string.IsNullOrEmpty(appo.ClientName))
            {
                //ClientName - name of the property
                ModelState.AddModelError("ClientName", "Please enter client name");
            }

            if(ModelState.IsValidField("Date") && DateTime.Now > appo.Date)
            {
                //can value be parsed?
                ModelState.AddModelError("Date", "Please enter future date");
            }

            if(!appo.TermsAccepted)
            {
                ModelState.AddModelError("TermsAccepted", "Please accept terms & conditions");
            }
            //model level validation error
            if (ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date") && appo.ClientName == "Gia" && appo.Date.DayOfWeek == DayOfWeek.Saturday)
            {
                ModelState.AddModelError("", "Gia cannot book appointments on Saturdays");
            }

            if (ModelState.IsValid)
            {
                return View("Completed", appo);
            }
            else
            {
                return View();
            }
        }
    }
}