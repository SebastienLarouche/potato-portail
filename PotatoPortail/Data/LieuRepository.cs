using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
//using PotatoPortail.Migrations;
using PotatoPortail.Models;

namespace PotatoPortail.Data
{
    public class LieuRepository
    {

        public IEnumerable<SelectListItem> getLieu()
        {
            using (var context = new BDPortail())
            {
                List<SelectListItem> lieu = context.LieuDeLaReunion.AsNoTracking().Select(local => new SelectListItem { Value = local.IdLieu.ToString(), Text = local.EmplacementReunion}).ToList();
                var defaut = new SelectListItem()
                {
                    Value = null,
                    Text = @"--- Saisissez un local ---"
                };
                lieu.Insert(0, defaut);
                return new SelectList(lieu, "Text", "Text");
            }
        }
    }
}