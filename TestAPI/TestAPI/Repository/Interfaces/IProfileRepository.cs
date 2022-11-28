using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProfileRepository
    {
        //Method to save the file
        public Boolean SaveProfileDataToFile(string fileName, string filePath, string _receivedProfileEntity);
    }
}
