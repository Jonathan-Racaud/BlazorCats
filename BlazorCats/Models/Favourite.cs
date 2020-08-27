using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCats.Models
{
    public class Favourite
    {
        public string Id { get; set; }
        public string ImageId { get; set; }
        public string SubId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
