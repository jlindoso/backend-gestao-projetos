using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ListResponse<T> where T:class
    {
        public IEnumerable<T> Data { get; set; }

        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}