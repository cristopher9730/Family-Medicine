using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

            OTP apiRespuestaOTP;

            var urlPrincipal = "https://localhost:44391";

            var url = urlPrincipal + "/api/OTP/ObtenerUnaOTP";

            var stringContent = new StringContent(JsonConvert.SerializeObject(otp), Encoding.UTF8, "application/json");

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);

            var result = cliente.PostAsync(url, stringContent).Result;

            if (result.IsSuccessStatusCode)
            {
                string jsonObject = result.Content.ReadAsStringAsync().Result;
                apiRespuestaOTP = JsonConvert.DeserializeObject<OTP>(jsonObject);
            }
            else
                throw new Exception(result.Content.ReadAsStringAsync().Result);

            if (apiRespuestaOTP.OTPId !=0)
            {
                return RedirectToAction("DashboardUsuario", "DashboardUsuario");
            }
            else
            {
                ViewBag.Message = "Codigo incorrecto";
                return RedirectToAction("OTP", "OTP");
            }
            
        }
    }
}