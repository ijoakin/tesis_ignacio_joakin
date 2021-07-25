using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PageServerSideDTO<T> where T: BaseDTO
    {
        public IList<T> Data { get; set; }
        public int Count { get; set; }
    }
}
