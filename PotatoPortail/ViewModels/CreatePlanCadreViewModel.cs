﻿using System;
using System.Collections.Generic;
using PotatoPortail.Models;

namespace PotatoPortail.ViewModels
{
    public class CreatePlanCadreViewModel: ApplicationPlanCadre.ViewModels.ViewModelBase
    {
        public ContenuSection ContenuSection { get; set; }
        public virtual List<NomSection> NomSection { get; set; }
        public virtual PlanCours PlanCours { get; set; }
        public virtual IEnumerable<PlanCadre> PlanCadre { get; set; }
        public int IdPlanCours { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateValidation { get; set; }
        public bool StatusPlanCours { get; set; }
    }
}