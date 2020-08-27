using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorCats.Models
{
    public class Breed
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Temperament { get; set; }
        public string LifeSpan { get; set; }
        public string AltName { get; set; }
        [JsonPropertyName("wikipedia_url")]
        public string WikipediaUrl { get; set; }
        public string Origin { get; set; }
        public Weight Weight { get; set; }
        public int Experimental { get; set; }
        public int Hairless { get; set; }
        public int Natural { get; set; }
        public int Rare { get; set; }
        public int Rex { get; set; }
        public int SuppressTail { get; set; }
        public int ShortLeg { get; set; }
        public int Hypoallergenic { get; set; }
        public int Adaptability { get; set; }
        public int AffectionLevel { get; set; }
        public string CountryCode { get; set; }
        public int ChildFriendly { get; set; }
        public int DogFriendly { get; set; }
        public int EnergyLevel { get; set; }
        public int Grooming { get; set; }
        public int Intelligence { get; set; }
        public int SheddingLevel { get; set; }
        public int SocialNeeds { get; set; }
        public int StrangerFriendly { get; set; }
        public int Vocalisation { get; set; }
    }

    public class Weight
    {
        public string Imperial { get; set; }
        public string Metric { get; set; }
    }
}
