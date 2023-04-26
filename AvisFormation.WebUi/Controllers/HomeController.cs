using AvisFormation.Data;
using AvisFormation.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Accueil()
        {
            var listFormation = new List<Formation>();
            var myList = new List<AccueilViewModel>();
            using (var context = new AvisEntities())
            {
                 listFormation = context.Formation.OrderBy(f=>Guid.NewGuid()).Take(4).ToList();
                foreach (var item in listFormation)
                {
                    var f = new AccueilViewModel();
                    f.FormationNomSeo = item.NomSeo;
                    f.FormationNom = item.Nom;
                    f.FormationDescription = item.Description;
                    if (item.Avis.Count != 0)
                    {
                        f.Note = item.Avis.Average(n => n.Note);
                        f.NombreAvis = item.Avis.Count();
                    }
                    else {
                        f.Note = 0;
                        f.NombreAvis = 0;
                    }
                    
                   
                    myList.Add(f);

                }
            }
            
                return View(myList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}