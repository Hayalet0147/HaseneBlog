using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Models
{
    public class BlogAddViewModel
    {
        public string BlogTitle { get; set; }
        public string Image { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogContent { get; set; }
        public bool BlogStatus { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public int WritersId { get; set; }
        public int CategoryId { get; set; }
    }
}
