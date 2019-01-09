using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp.Authentication.Dtos
{
    public enum Status
    {
        Success = 0,
        Fail = 1
    }
    public class ResponseDto
    {
        public object Data { get; set; }
        public Status Status { get; set; }
        public string Msg { get; set; }
    }
}
