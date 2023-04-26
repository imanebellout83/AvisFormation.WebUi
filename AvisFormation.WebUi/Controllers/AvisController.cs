using AvisFormation.Data;
using AvisFormation.Logic;
using AvisFormation.WebUi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AvisFormation.WebUi.Controllers
{
    public class AvisController : Controller
    {
        // GET: Avis
        [Authorize]
        public ActionResult AjouterUnAvis(string nomSeo)
        {
            var userName = User.Identity.Name;
            var userId = User.Identity.GetUserId();
            var vm = new LaisserUnAvisViewModel();
            vm.NomSeo = nomSeo;
            using (var context = new AvisEntities())
            { 
                var formation = context.Formation.FirstOrDefault(f=>f.NomSeo==nomSeo);
                

                if (formation == null)
                {
                    return RedirectToAction("Accueil", "Home");
                }
                //modification
                /*if  (formation != null) {
                    var avis = context.Avis.FirstOrDefault(a => a.UserId == userId);
                     if  (avis != null) 
                      {
                        return RedirectToAction("ToutsLesFormations", "Formation");

                      }*/
                     //fin modification
                    vm.FormationName = formation.Nom;

                
                
                
            }

            return View(vm);
        }
        
         public ActionResult SaveComment(SaveCommentViewModel comment)
        {



            var mgr = new PersonneManager();
            var userId = User.Identity.GetUserId();


            var newAvis = new Avis();
            newAvis.DateAvis = DateTime.Now;
            newAvis.Note = double.Parse(comment.note);
            newAvis.Description = comment.commentaire;
            newAvis.Nom = mgr.GetNameFromUserId(userId);
            newAvis.UserId = userId;
            var formation = new Formation();
            

            using (var context = new AvisEntities())
            {
                 formation = context.Formation.FirstOrDefault(f => f.NomSeo == comment.nomSeo);
                if (formation == null)
                {
                    return RedirectToAction("Accueil", "Home");
                }
                newAvis.IdFormation = formation.Id;
                var mgrUnique = new UniqueAvisVirification();
                if (!mgrUnique.EstAutorisesAcommenter(userId, formation.Id))
                {
                    TempData["message"] = "Désoler,vous avez déja donner votre avis !";
                    return RedirectToAction("DetailsFormations", "Formation", new {nomSeo=comment.nomSeo});
                }

                    context.Avis.Add(newAvis);
                context.SaveChanges();
            }              
                return RedirectToAction("DetailsFormations", "Formation", new {nomSeo=formation.NomSeo});
        }
    }
}