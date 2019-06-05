using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.API.Helpers
{
    public class ReturnViewModel
    {
        public HttpStatusCode Code { get; private set; }

        public object Data { get; private set; }

        public bool Error { get; private set; }

        public ReturnViewModel(HttpStatusCode code, object data, bool error)
        {
            this.Code = code;
            this.Data = data;
            this.Error = error;
        }
    }
}
