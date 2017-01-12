using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.FilterViewModels
{
    public class FilterCriteria
    {
        public int? silhouette { get; set; }
        public int? neklijn { get; set; }
        public int? gefilterdeKleur { get; set; }
        public int? categorieID { get; set; }
        public int? stijl { get; set; }
        public int? minPrijs { get; set; }
        public int? maxPrijs { get; set; }
        public int? merk { get; set; }
        public string sorteer { get; set; }
        public int? limiet { get; set; }
        public int? paginering { get; set; }

        public bool isEmpty()
        {
            return true;
            //silhouette.Count() > 0 && neklijn.Count() > 0 && gefilterdeKleur.Count() > 0 &&
               // categorieID == null && stijl == null && minPrijs == null && 
               // maxPrijs == null && merk.Count() > 0 
               // && sorteer == null && sorteer != "" && limiet == null && paginering == null;
        }
    }
}
