using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCats.Models
{
    public enum SearchOrder
    {
        Rand,
        Asc,
        Desc,
    }

    public class SearchFilters
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public SearchOrder Order { get; set; }

        public bool AreSet()
        {
            return ((Limit != 0) || (Page != 0) || (!Order.Equals(SearchOrder.Rand)));
        }

        public override string ToString()
        {
            if (!AreSet())
            {
                return "";
            }

            var filters = "?";

            if ((Limit != 0) || (Page != 0) || (Order != SearchOrder.Rand))
            {
                filters += "?";
                filters += $"{((Limit != 0) ? ("limit=" + Limit.ToString() + "&") : (""))}";
                filters += $"{((Page != 0) ? ("page=" + Page.ToString() + "&") : (""))}";
                filters += $"{((Order != SearchOrder.Rand) ? ("order=" + Order.ToString().ToUpper()) : (""))}";
            }

            return filters;
        }
    }
}
