using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace Repository.Classes
{
    public class ProfileRepository : IProfileRepository
    {
        //Method to save the file
        public Boolean SaveProfileDataToFile(string fileName, string filePath, string _receivedProfileEntity)
        {
            ProfileDetails objProfile = new ProfileDetails();
            objProfile.SaveProfileDataToFile(fileName, filePath, _receivedProfileEntity);
            return true;
        }

    }
}
