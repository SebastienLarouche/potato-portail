using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PotatoPortail.Models.eSports
{
    public partial class Jeu
    {
        public Jeu()
        {
            Equipe = new HashSet<Equipe>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom du jeu")]
        public string NomJeu { get; set; }

        [Display(Name = "Description du jeu")]
        public string Description { get; set; }

        [Display(Name = "Adresse du site officiel")]
        public string UrlReference { get; set; }

        [Required]
        [Display(Name = "Abr�viation")]
        [StringLength(6, MinimumLength = 2, ErrorMessage = "L'abr�viation doit avoir entre 2 et 6 caract�res.")]
        public string Abreviation { get; set; }

        [Display(Name = "Statut du jeu")]
        public int IdStatut { get; set; }

        public virtual ICollection<Caracteristique> Caracteristique { get; set; }

        public virtual ICollection<Equipe> Equipe { get; set; }

        public virtual ICollection<Profil> Profil { get; set; }

        public virtual ICollection<Rang> Rang { get; set; }

        public virtual Statut Statut { get; set; }
    }
}
