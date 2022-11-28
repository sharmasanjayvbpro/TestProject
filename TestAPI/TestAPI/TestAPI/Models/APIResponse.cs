using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TestAPI.Models
{

    // API Response Entity
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
