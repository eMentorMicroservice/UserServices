using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace eMentor.Common.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            IsSuccess = false;
        }

        public HttpStatusCode Status { get; set; }

        public string Error { get; set; }

        public bool IsSuccess { get; set; } = false;

        public object Data { get; set; }
    }
}
