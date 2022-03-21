using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Contracts
{
    public class Response<T>
    {
        public Header Header { get; set; }

        public T Data { get; set; }

        public Response()
        {
            Header = new Header();
            Header.Code = 200;
        }
    }

    public class Header
    {
        public int Code { get; set; }

        public string Message { get; set; }
    }
}
