using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestProject.Areas.Profile.Models;
using TestProject.Models;
using NLog;
using TestProject.Filter;

namespace TestProject.Areas.Profile.Controllers
{
    public class ProfileDetailsController : Controller
    {
        //Initialize the logger
        Logger _logger = LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            return View();
        }

        [AppException] //Filter to log exception.
        [HttpPost]
        public ActionResult Index(ProfileEntity _personEntity)
        {
            _logger.Info(ProjectConstants.CheckIfModelIsValid);
            if (ModelState.IsValid == true) //Check if model is valid or not
            {
                //API call to save data
                _logger.Info(ProjectConstants.APIExecutionStart);
                APIResponse _apiResponse = CommonRoutines.CallApi(ProjectConstants.saveJSONToServer, _personEntity, false);
                if (_apiResponse.statuscode == HttpStatusCode.OK) //Check if data is saved successfully
                {
                    ModelState.Clear(); //Clear model after saving.
                    ViewBag.SuccessMessage = ProjectConstants.SuccessAfterSavingDetails;
                    return View(ProjectConstants.ProfileDetails);
                }
                ViewBag.ErrorMessage = ProjectConstants.ErrorWhileSavingDetails;
                _logger.Info(ProjectConstants.APIExecutionEnd);
                return View(ProjectConstants.ProfileDetails);
                
            }
            else //If model is not valid
            {
                ViewBag.ErrorMessage = ProjectConstants.EnterMandatoryFields;
                _logger.Error(ProjectConstants.EnterMandatoryFields);
                return View(ProjectConstants.ProfileDetails);
            }
        }
    }
}