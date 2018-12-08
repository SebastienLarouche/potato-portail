using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PotatoPortail.Models.eSports
{
    public partial class Entraineur
    {
        public Entraineur()
        {
            Equipe = new HashSet<Equipe>();
        }

        public string NomComplet => PrenomEntraineur + NomEntraineur;

        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string NomEntraineur { get; set; }

        [Required]
        [Display(Name = "Pr�nom")]
        public string PrenomEntraineur { get; set; }

        [Required]
        [Display(Name = "Pseudo")]
        public string PseudoEntraineur { get; set; }

        [Required]
        [Display(Name = "Num�ro de t�l�phone")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Veuillez entrer un num�ro de t�l�phone valide.")]
        public string NumeroTelephone { get; set; }

        [Required]
        [Display(Name = "Adresse courriel")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Veuillez entrer une adresse courriel valide.")]
        public string AdresseCourriel { get; set; }

        public virtual ICollection<Equipe> Equipe { get; set; }
    }
}
