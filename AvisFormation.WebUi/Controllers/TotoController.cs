using AvisFormation.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AvisFormation.WebUi.Models.MyViewModel;

namespace AvisFormation.WebUi.Controllers
{
    public class TotoController : Controller
    {
        // GET: Toto
        public ActionResult Index()
        {
            var vm = new MyViewModel();
            vm.Message = "Soyez sur de votre choix!";
            vm.Ville = new List<string>();
            vm.Ville.Add("Meknes");
            vm.Ville.Add("Rabat");
            vm.Ville.Add("CasaBlanca");
            vm.FormationGender = new Gender();
            
            return View(vm);
        }
    }
}