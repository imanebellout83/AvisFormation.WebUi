using AvisFormation.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.WebUi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactViewModel contact )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("epim.di22@gmail.com", "epim");
                    var receiverEmail = new MailAddress("epim.di22@gmail.com" , "Receiver");
                    var password = "epim2022";
                    var sub = contact.nom;
                    var body = contact.message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = contact.nom,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
    }
}