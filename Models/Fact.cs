using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCats.Models
{
    public class Fact
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string LanguageCode { get; set; }
        public string BreedId { get; set; }
    }
}
