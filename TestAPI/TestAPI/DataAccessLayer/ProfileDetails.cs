namespace DataAccessLayer
{
   
    public class ProfileDetails
    {

        //Method to save file
        public Boolean SaveProfileDataToFile(string fileName, string filePath, string _receivedProfileEntity)
        {

            using (StreamWriter outputFile = System.IO.File.AppendText(Path.Combine(filePath, fileName)))
                 outputFile.WriteLineAsync(_receivedProfileEntity);

            return true;

        }
    }
}