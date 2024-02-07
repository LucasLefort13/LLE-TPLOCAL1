using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using TPLOCAL1.Models;

public class HomeController : Controller
{
    // Méthode appelée naturellement par le routeur
    public ActionResult Index(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            // Retourner à la vue Index (voir le routage dans Program.cs)
            return View();
        }
        else
        {
            // Appeler différentes pages en fonction de l'identifiant passé en paramètre
            switch (id)
            {
                case "AvisList":
                    // Charger la vue OpinionList
                    ViewBag.HeaderTitle = "Liste des avis";
                    return View("OpinionList");
                case "Form":
                    // Charger la vue du formulaire avec un modèle de données vide
                    var model = new FormModel();
                    ViewBag.HeaderTitle = "Bienvenue sur le formulaire de TP HN";
                    return View("Form", model);
                default:
                    // Retourner à la vue Index (voir le routage dans Program.cs)
                    return View();
            }
        }
    }

    // Méthode pour envoyer les données du formulaire à la page de validation
    [HttpPost]
    [HttpPost]
    public ActionResult ValidationForm(FormModel model)
    {
        // Vérifications des champs et ajout des erreurs
        if (string.IsNullOrEmpty(model.Nom))
        {
            ModelState.AddModelError("Nom", "Le nom est requis.");
        }
        else if (model.Nom.Length < 2 || model.Nom.Length > 50)
        {
            ModelState.AddModelError("Nom", "Le nom doit contenir entre 2 et 50 caractères.");
        }

        if (string.IsNullOrEmpty(model.Prenom))
        {
            ModelState.AddModelError("Prenom", "Le prénom est requis.");
        }
        else if (model.Prenom.Length < 2 || model.Prenom.Length > 50)
        {
            ModelState.AddModelError("Prenom", "Le prénom doit contenir entre 2 et 50 caractères.");
        }

        if (string.IsNullOrEmpty(model.Genre))
        {
            ModelState.AddModelError("Genre", "Le genre est requis.");
        }

        if (string.IsNullOrEmpty(model.Ville))
        {
            ModelState.AddModelError("Ville", "La ville est requise.");
        }

        if (string.IsNullOrEmpty(model.TypeFormation))
        {
            ModelState.AddModelError("TypeFormation", "Le type de formation est requis.");
        }

        if (string.IsNullOrEmpty(model.Adresse))
        {
            ModelState.AddModelError("Adresse", "L'adresse est requise.");
        }
        else if (model.Adresse.Length < 5 || model.Adresse.Length > 100)
        {
            ModelState.AddModelError("Adresse", "L'adresse doit contenir entre 5 et 100 caractères.");
        }

        if (!Regex.IsMatch(model.CodePostal, @"^\d{5}$"))
        {
            ModelState.AddModelError("CodePostal", "Le code postal doit être composé de 5 chiffres.");
        }

        if (model.DateDebutFormation > DateTime.Today)
        {
            ModelState.AddModelError("DateDebutFormation", "La date de début de la formation doit être antérieure à la date actuelle.");
        }

        // Autres vérifications...

        if (ModelState.IsValid)
        {
            // Modèle valide, poursuivre avec votre logique
            ViewBag.HeaderTitle = "Page de validation";
            return View("Validation", model);
        }
        else
        {
            // Modèle invalide, retourner à la vue du formulaire avec les erreurs
            return View("Form", model);
        }
    }

}

