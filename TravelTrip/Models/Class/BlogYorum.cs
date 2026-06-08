using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelTrip.ViewModels;

namespace TravelTrip.Models.Class
{
    public class BlogYorum
    {
      public IEnumerable<TravelTrip.ViewModels.BlogSumViewModel> DegerBlog { get; set; }
      public IEnumerable<Blog> Deger1 { get; set; }
      public IEnumerable<Yorumlar> Deger2 { get; set; }
      public IEnumerable<Blog> Deger3 { get; set; }
    }
}