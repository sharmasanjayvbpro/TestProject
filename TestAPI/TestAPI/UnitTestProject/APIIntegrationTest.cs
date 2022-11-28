using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using TestAPI.Controllers;
using TestAPI.Models;
using Repository.Classes;
using System.Net;

namespace TestAPIIntegrationTesting
{
    public class APIIntegrationTest
    {
        //Define the configration/repository variables
        IConfiguration _configWithValues = A.Fake<IConfiguration>();
        IConfiguration _configWithNoValues = A.Fake<IConfiguration>();

        IProfileRepository _iProfile = new ProfileRepository();


        
        [SetUp]
        public void Setup()
        {
            //Set the values for configuration variables.
            var myConfiguration = new Dictionary<string, string>
        {
            {"FilePath", "E:\\" },
            {"FileNameInitial", "ProfileData_" },
                        {"FileExtension", ".txt" }

        };
            _configWithValues = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
            .Build();
        }

        [Test]
        public void SaveProfileDetails_Success()
        {

            var _profileCon = new ProfileController(_configWithValues, _iProfile);

            var _resCon = _profileCon.SaveProfileDetails(new TestAPI.Models.ProfileEntity
            {
                FirstName = "TestProjectFirstName",
                LastName = "TestProjectLastName",
                CreatedDateTime = DateTime.UtcNow
            });
            //Check if response is Ok 
            Assert.That(((APIResponse)(_resCon.Result as OkObjectResult).Value).statuscode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void SaveProfileDetails_Failure()
        {
            var _profileCon = new ProfileController(_configWithNoValues, _iProfile);

            var _resCon = _profileCon.SaveProfileDetails(new TestAPI.Models.ProfileEntity());
            //Check if response is Bad Request 
            Assert.That(((APIResponse)(_resCon.Result as BadRequestObjectResult).Value).statuscode,  Is.EqualTo(HttpStatusCode.BadRequest));
        }


    }
}