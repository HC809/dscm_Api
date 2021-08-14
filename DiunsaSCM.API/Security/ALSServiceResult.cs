using System;
using System.Collections.Generic;

namespace DiunsaSCM.API.Security
{
    public class ALSServiceResult<T>
    {
        public int ResponseCode { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
