using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTrip.Models.Class
{
    public class Hakkimizda
    {
        [Key]
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Aciklama { get; set; }
    }
}