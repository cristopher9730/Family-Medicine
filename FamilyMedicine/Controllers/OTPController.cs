using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class OTPController : Controller
    {
        // GET: OTP
        public ActionResult OTP()
        {
            return View();
        }

        [HttpGet]
        public ActionResult OTP(OTP otp)
        {
            var CodigoOtp = otp.CodigoOTP;
            return RedirectToAction("Index", "Home");
        }
    }
}