using AvisFormation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.WebUi.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult ToutsLesAvis()
        {
            var listAvis = new List<Avis>();
            using (var contexte = new AvisEntities())
            {
                listAvis = contexte.Avis.ToList();

            }

            return View(listAvis);
        }
    }
}