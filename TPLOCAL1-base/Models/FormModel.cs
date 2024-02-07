using System;
using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        // Nom
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre {2} et {1} caractères")]
        public string Nom { get; set; }

        // Prénom
        [Required(ErrorMessage = "Le prénom est requis")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le prénom doit contenir entre {2} et {1} caractères")]
        public string Prenom { get; set; }

        // Genre
        [Required(ErrorMessage = "Le genre est requis")]
        public string Genre { get; set; }

        // Adresse
        [Required(ErrorMessage = "L'adresse est requise")]
        [StringLength(100, ErrorMessage = "L'adresse ne peut pas dépasser {1} caractères")]
        public string Adresse { get; set; }

        // Code postal
        [Required(ErrorMessage = "Le code postal est requis")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit être composé de 5 chiffres")]
        public string CodePostal { get; set; }

        // Ville
        [Required(ErrorMessage = "La ville est requise")]
        [StringLength(50, ErrorMessage = "La ville ne peut pas dépasser {1} caractères")]
        public string Ville { get; set; }

        // Adresse e-mail
        [Required(ErrorMessage = "L'adresse e-mail est requise")]
        [EmailAddress(ErrorMessage = "Format d'adresse e-mail invalide")]
        public string Email { get; set; }

        // Date de début de la formation
        [Required(ErrorMessage = "La date de début de la formation est requise")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de début de la formation")]
        [ValidDate(ErrorMessage = "La date de début de la formation doit être antérieure à la date actuelle")]
        public DateTime DateDebutFormation { get; set; } = DateTime.Today;

        // Type de formation
        [Required(ErrorMessage = "Le type de formation est requis")]
        public string TypeFormation { get; set; }

        // Avis sur la formation Cobol
        public string AvisCobol { get; set; }

        // But de la formation
        public string ButFormation { get; set; }
    }

    // Custom validator pour la date de début de la formation
    public class ValidDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // Si la valeur est null, elle est considérée comme invalide
            if (value == null)
            {
                return false;
            }

            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date < DateTime.Now;
            }
            return false;
        }
    }
}
