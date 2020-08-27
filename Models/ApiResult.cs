using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlazorCats.Models
{
    public class ApiResult<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Value { get; set; }

        public ApiResult(HttpStatusCode code = HttpStatusCode.OK, T value = default)
        {
            StatusCode = code;
            Value = value;
        }
    }
}
