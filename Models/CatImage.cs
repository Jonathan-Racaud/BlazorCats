using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCats.Models
{
    public class CatImage
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string SubId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OriginalFilename { get; set; }

        public IList<Category> Categories { get; set; }
        public IList<Breed> Breeds { get; set; }
    }
}
