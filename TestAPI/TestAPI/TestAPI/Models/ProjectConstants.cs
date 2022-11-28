using System.ComponentModel;
using System.Net;

namespace TestAPI.Models
{
    //Application Constants
    public static class ProjectConstants
    {
        public static readonly string version = "1.0.0.0";
        public static readonly HttpStatusCode StatusCodeOK = HttpStatusCode.OK;
        public static readonly string SuccessMessage = "Success";
        public static readonly HttpStatusCode StatusCodeBadRequest = HttpStatusCode.BadRequest;
        public static readonly string BadRequestMessage = "Bad Request";
        public static readonly string JSONNotValidMessage = "JSON Not Valid";

        //Generic Messages
        public static readonly string APIExecutionStart = "API Execution Started";

        public static readonly string APIExecutionEnd = "API Execution Ends";

        public static readonly string ErrorWhileSavingDetails = "Error While Saving Details To File";

       

    }
}
