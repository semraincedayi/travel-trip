using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTrip.ViewModels
{
    public class BlogSumViewModel
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string BlogImage { get; set; }
        public string KisaAciklama { get; set; }
    }
}