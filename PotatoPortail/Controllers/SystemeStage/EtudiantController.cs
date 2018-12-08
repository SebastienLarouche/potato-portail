using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PotatoPortail.Migrations;
using PotatoPortail.Models;

namespace PotatoPortail.Controllers.SystemeStage
{
    public class EtudiantController : Controller
    {
        private readonly BdPortail _bd = new BdPortail();

        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/SystemeStage/Etudiant/Index.cshtml", _bd.Etudiant.ToList());
        }

        [HttpPost]
        public ActionResult Edition(int? idEtudiant)
        {
            if (idEtudiant == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var etudiant = _bd.Etudiant.Find(idEtudiant);

            if (etudiant == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View("~/Views/SystemeStage/Etudiant/Edition.cshtml", etudiant);
        }

        [HttpPost]
        public ActionResult EnregistrerLesModifications(
            int? idEtudiant,
            string telephone,
            string prenom,
            string role,
            string codePermanent,
            string courrielEcole,
            string courrielPersonnel,
            string numeroDa,
            string nomDeFamille,
            int? idLocation,
            int? idEntreprise,
            int? idPoste,
            float salaire
        )
        {
            if (idEtudiant == null || idEntreprise == null || idLocation == null || idPoste == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var etudiant = _bd.Etudiant.Find(idEtudiant);
            var poste = _bd.Poste.Find(idPoste);
            var location = _bd.Location.Find(idLocation);
            var entreprise = _bd.Entreprise.Find(idEntreprise);

            if (etudiant == null || poste == null || location == null || entreprise == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            etudiant.Telephone = telephone;
            etudiant.Prenom = prenom;
            etudiant.Role = role;
            etudiant.CodePermanent = codePermanent;
            etudiant.CourrielEcole = courrielEcole;
            etudiant.CourrielPersonnel = courrielPersonnel;
            etudiant.NumeroDa = numeroDa;
            etudiant.NomDeFamille = nomDeFamille;

            etudiant.Preference.Poste = new List<Poste> {poste};
            etudiant.Preference.Entreprise = new List<Entreprise> {entreprise};
            etudiant.Preference.Location = new List<Location> {location};
            etudiant.Preference.Salaire = salaire;

            _bd.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Creation()
        {
            var etudiant = new Etudiant
            {
                Telephone = "123-456-7890",
                Preference = new Preference
                {
                    Salaire = 0,
                },
                Prenom = "prénom",
                NomDeFamille = "nom de famille",
                Role = "etudiant",
                CodePermanent = "ABCD12345678",
                CourrielEcole = "email@cegepjonquiere.ca",
                CourrielPersonnel = "email@cegepjonquiere.ca",
                NumeroDa = "1234567",
            };


            return View("~/Views/SystemeStage/Etudiant/Edition.cshtml", etudiant);
        }

        [HttpPost]
        public ActionResult ConsulterDossierEtudiant(int? idEtudiant)
        {
            if (idEtudiant == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var etudiant = _bd.Etudiant.Find(idEtudiant);

            if (etudiant == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View("~/Views/SystemeStage/Etudiant/Actions/DossierEtudiant.cshtml", etudiant);
        }

        public ActionResult Suppression(int? id)
        {
            var etudiant = _bd.Etudiant.Find(id);

            if (etudiant == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var applicationsParCetEtudiant = from application in _bd.Application
                                             where application.Etudiant.IdEtudiant == id
                                             select application;

            if (!applicationsParCetEtudiant.Any())
            {
                _bd.Etudiant.Remove(etudiant);
                _bd.SaveChanges();
            }

            return RedirectToAction("Index", "Etudiant");
        }
    }
}