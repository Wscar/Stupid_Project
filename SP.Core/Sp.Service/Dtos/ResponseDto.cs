using System;
using System.Collections.Generic;
using System.Text;

namespace Sp.Service.Dtos
{  
  public enum Status
    {
         Success=0,
         Fail=1
    }
  public  class ResponseDto
    {
        public object Data { get; set; }
        public  Status Status { get; set; }
        public string Msg { get; set; }

        public static ResponseDto Success(object Data)
        {
            return new ResponseDto { Data=Data,Status= Status.Success };

        }
        public static ResponseDto Fail(string msg)
        {
            return new ResponseDto {
                Status = Status.Fail,
                Msg = msg
            };            
        }
    }
}
