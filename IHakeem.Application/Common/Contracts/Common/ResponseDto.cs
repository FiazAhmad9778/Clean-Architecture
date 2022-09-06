using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace iHakeem.Application.Common.Contracts.Common
{
    public class ResponseDto<T>
    {
        public int Status { get; set; }
        public string Message { get; set; } = "Success";
        public T Data { get; set; }

    }
}
