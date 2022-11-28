using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TestProject.Models
{
    //API Response Entity
    public class APIResponse
    {
        public string version { get; set; }
        public HttpStatusCode statuscode { get; set; }
        public string message { get; set; }
        public string filename { get; set; }
        public DateTime timestamp { get; set; }
        public string size { get; set; }
    }

}