<<<<<<< HEAD
﻿using ApplicationPlanCadre.ViewModels.OrdresDuJourVM;
//using PotatoPortail.Model.ReunionsViewModel;

namespace PotatoPortail.Data
{
    public class CreateRepository
    {
        
        public OrdreDuJourViewModel CreateLieu()
        {
            var lieuRepo = new LieuRepository();

            var allLieu = new OrdreDuJourViewModel()
            {
                listLieux = lieuRepo.getLieu()
            };

            return allLieu;
        }
    }
=======
﻿
using PotatoPortail.ViewModels.OrdresDuJour;

namespace PotatoPortail.Data
{
    public class CreateRepository
    {
        
        public OrdreDuJourViewModel CreateLieu()
        {
            var lieuRepo = new LieuRepository();

            var allLieu = new OrdreDuJourViewModel()
            {
                ListLieux = lieuRepo.GetLieu()
            };

            return allLieu;
        }
    }
>>>>>>> origin/dev
}