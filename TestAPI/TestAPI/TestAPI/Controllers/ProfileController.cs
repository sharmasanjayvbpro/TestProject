using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using NLog;
using Repository.Interfaces;
using Repository.Classes;
using TestAPI.Filter;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    public class ProfileController : ControllerBase
    {

        //Variable Section
        private readonly IConfiguration _config;
        private readonly IProfileRepository _iprofile;
        Logger _logger = LogManager.GetCurrentClassLogger();
        string filePath, fileName;


        //Constructor to initialize the variables using dependency. 
        public ProfileController(IConfiguration config, IProfileRepository profile)
        {
            _config = config;
            _iprofile = profile;
        }

        [AppException] //For error logging 
        [Route("api/saveProfileDetails")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> SaveProfileDetails([FromBody] ProfileEntity _profileEntiry)
        {

            _logger.Info(ProjectConstants.APIExecutionStart); // Log the execution start
            _profileEntiry.CreatedDateTime = DateTime.UtcNow;
            string _receivedProfileEntity = System.Text.Json.JsonSerializer.Serialize(_profileEntiry);
            int fileSize = _receivedProfileEntity.Length * sizeof(Char); // Get the file size

            if (fileSize > 0) //Check if passed data is valid
            {
                filePath = _config.GetValue<string>("FilePath"); //Get file path from setting file.
                fileName = _config.GetValue<string>("FileNameInitial") 
                    + DateTime.Now.ToString("ddMMyyyy") 
                    + _config.GetValue<string>("FileExtension"); //Get file name from setting file & todays date.
                
                //Check if file path is valid & data is saved to file.
                if (filePath.Length>0 && _iprofile.SaveProfileDataToFile(fileName, filePath, _receivedProfileEntity))
                {
                    _logger.Info(ProjectConstants.APIExecutionEnd); // log the final status for API execution

                    //Return the response to client.
                    return Ok(new APIResponse
                    {
                        version = ProjectConstants.version, statuscode = ProjectConstants.StatusCodeOK,
                        message = ProjectConstants.SuccessMessage, filename = fileName, 
                        timestamp = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                        size = fileSize.ToString() + _config.GetValue<string>("SizeMeasurementUnit")
                    });
                }
            }

            _logger.Error(ProjectConstants.ErrorWhileSavingDetails); //Log if there is any error

            //Return the response to client.
            return BadRequest(new APIResponse
            {
                version = ProjectConstants.version, statuscode = ProjectConstants.StatusCodeBadRequest,
                message = ProjectConstants.JSONNotValidMessage, timestamp = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            });



        }
    }
}
