using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace Tekno_Yazılım.Models.BlogModel
{
    public class Bloglistelememodeli
    {

        public List<Blog>? Blogs { get; set; }
        public SelectList? Title { get; set; }
        public string? BlogTitle { get; set; }
        public string? SearchString { get; set; }
    }
}
