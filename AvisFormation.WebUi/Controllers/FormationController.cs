using AvisFormation.Data;
using AvisFormation.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.WebUi.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        public ActionResult ToutesLesFormations()
        {
            var listFormation = new List<Formation>();
            var myList = new List<AccueilViewModel>();
            using (var context = new AvisEntities())
            {
                listFormation = context.Formation.ToList();
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
                    else
                    {
                        f.Note = 0;
                        f.NombreAvis = 0;
                    }


                    myList.Add(f);

                }
            }

            return View(myList);
        }
        public ActionResult DetailsFormations(string nomSeo)
        {
            var formation = new Formation();
            var vm = new FormationAvecAvisViewModel();
            using (var context = new AvisEntities())
            {
                formation = context.Formation.Where(x => x.NomSeo == nomSeo).FirstOrDefault();
                if (formation == null)
                {
                    return RedirectToAction("Accueil", "Home");
                }
               
                vm.FormationNom = formation.Nom;
                vm.FormationDescription = formation.Description;
                vm.FormationNomSeo = formation.NomSeo;
                vm.FormationUrl = formation.Url;
                if (formation.Avis.Count != 0)
                {
                    vm.Note = formation.Avis.Average(n => n.Note);
                    vm.NombreAvis = formation.Avis.Count;
                }
                else
                {
                    vm.Note = 0;
                    vm.NombreAvis = 0;
                }
                vm.FormationAvis = formation.Avis.ToList();
            }

            return View(vm);
        }
     

    }
     
}