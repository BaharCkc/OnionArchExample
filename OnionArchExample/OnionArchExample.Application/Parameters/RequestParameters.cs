using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchExample.Application.Parameters
{
    public class RequestParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public RequestParameters(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
