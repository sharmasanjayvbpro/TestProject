using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Configuration;

namespace TestProject.Models
{
    public class CommonRoutines
    {

        //Get the service URL from app setting file
        public static string GetServiceURL(string serviceName)
        {
            return WebConfigurationManager.AppSettings["APIBaseUrl"].ToString() + WebConfigurationManager.AppSettings["APIBaseUrlPath"].ToString() + serviceName;
        }

        //Method to get/post the request
        public static APIResponse CallApi(string url, object data, bool isList)
        {
            APIResponse responsePacket = new APIResponse();
            string DetailUrl = CommonRoutines.GetServiceURL(url);
            string serializeJasonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            try
            {
               using (var client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    string HtmlResult = client.UploadString(new Uri(DetailUrl),"POST", serializeJasonData);
                    
                    responsePacket = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(HtmlResult, new JsonSerializerSettings
                    {                   
                    });
                }
            }

            catch (WebException ex)
            {
              responsePacket.message = ex.Message;
            }
            return responsePacket;
        }
      
    }
}