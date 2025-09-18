using EmailContactService.Models;
using EmailContactService.Models.ContactEmailModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace EmailContactService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactEmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mail = new MailMessage();
                    mail.To.Add("abcd@gmail.com");// Mesaj G�nderilecek e-posta
                    mail.From = new MailAddress(model.Email); // Kullan�c�n�n e-posta adresi
                    mail.Subject = model.Subject;
                    mail.Body = $"G�nderen: {model.Name} <{model.Email}>\nMesaj: {model.Message}";

                    // SMTP Client ile mail g�nderimi
                    using (var smtp = new SmtpClient("smtp.gmail.com", 587)) // Gmail SMTP sunucusu ve portu e�er isterseniz OUTLOOK i�in "smtp.office365.com" ve port 587 kullan�labilir.
                    {
                        smtp.Credentials = new NetworkCredential("abcd@gmail.com", "AppPasswordKey"); //  Mesaj G�nderilecek e-posta k�sm� , burada Gmail hesab�n�n **uygulama �ifresi (App Password)** kullan�l�yor.
                        smtp.EnableSsl = true;
                        smtp.Send(mail); // Mail g�nderim
                    }

                    ViewBag.Message = "Mesaj g�nderildi!";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Hata: " + ex.Message;
                }
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
