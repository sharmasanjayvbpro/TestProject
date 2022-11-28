using System.ComponentModel;
using System.Net;

namespace TestProject
{
    public static class ProjectConstants
    {
        //Controller-Action Name
        public static readonly string ProfileDetails = "Index";
       
        //API Name
        public static readonly string saveJSONToServer = "saveProfileDetails";

        //Generic Messages
        public static readonly string CheckIfModelIsValid = "Check if model is valid";

        public static readonly string ErrorWhileSavingDetails = "Error While Saving Profile Details";

        public static readonly string SuccessAfterSavingDetails = "Profile Details Saved Successfully";

        public static readonly string EnterMandatoryFields = "Please Enter Mandatory Fields";

        public static readonly string APIExecutionStart = "API Execution Started";

        public static readonly string APIExecutionEnd = "API Execution Ends";

    }
}
