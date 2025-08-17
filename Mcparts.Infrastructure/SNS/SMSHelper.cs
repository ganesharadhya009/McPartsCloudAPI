using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.SNS
{
    public class SMSSettings
    {
        public string? URL { get; set; }
        public string? AuthKey { get; set; }
        public string? SenderId { get; set; }
        public string? Route { get; set; }
    }

    public interface ISMSHelper
    {
        public Task<bool> SendSMS(string mobileNumber, string text);
    }

    public class SMSHelper : ISMSHelper
    {
        private readonly SMSSettings _SMSSettings;
        public SMSHelper(IOptions<SMSSettings> smtpSettings)
        {
            _SMSSettings = smtpSettings.Value;
        }

        public async Task<bool> SendSMS(string mobileNumber, string text)
        {
            using var httpClient = new HttpClient();

            // Define the form parameters as a Dictionary
            var formData = new Dictionary<string, string>
            {
                { "authkey", _SMSSettings.AuthKey },
                { "mobiles", mobileNumber },
                { "message", text },
                { "sender", _SMSSettings.SenderId },
                { "route", _SMSSettings.Route }
            };

            // Create FormUrlEncodedContent from the dictionary.
            // This automatically handles URL encoding and sets the Content-Type header.
            var content = new FormUrlEncodedContent(formData);

            // Define the target URL
            string requestUri = _SMSSettings.URL; // Replace with your actual endpoint

            try
            {
                // Send the POST request
                HttpResponseMessage response = await httpClient.PostAsync(requestUri, content);

                // Check if the request was successful
                var test = response.EnsureSuccessStatusCode(); // Throws an exception for HTTP error codes

                // Read the response content (optional)
                string responseBody = await response.Content.ReadAsStringAsync();
                return true;

            }
            catch (HttpRequestException e)
            {
                return false;
            }
        }

        //public readonly string authKey;
        //public readonly string senderId;
        //public readonly string route;
        //public static async Task SendSMS()
        //{
        //    string authKey = "440766A4btTemuKxR68977c7aP1";
        //    string mobileNumber = "918884600066";
        //    string senderId = "MACMYS";
        //    string message = HttpUtility.UrlEncode("Test message");
        //    using var client = new HttpClient();

        //    //Prepare you post parameters
        //    StringBuilder sbPostData = new StringBuilder();
        //    sbPostData.AppendFormat("authkey={0}", authKey);
        //    sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
        //    sbPostData.AppendFormat("&message={0}", message);
        //    sbPostData.AppendFormat("&sender={0}", senderId);
        //    sbPostData.AppendFormat("&route={0}", "4");
        //    //sbPostData.AppendFormat("&route={0}", "default");

        //    //Call Send SMS API
        //    string sendSMSUri = "http://api.msg91.com/api/sendhttp.php";
        //    //Create HTTPWebrequest
        //    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
        //    //Prepare and Add URL Encoded data
        //    UTF8Encoding encoding = new UTF8Encoding();
        //    byte[] data = encoding.GetBytes(sbPostData.ToString());
        //    //Specify post method
        //    httpWReq.Method = "POST";
        //    httpWReq.ContentType = "application/x-www-form-urlencoded";
        //    httpWReq.ContentLength = data.Length;
        //    using (Stream stream = httpWReq.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }
        //    //Get the response
        //    HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
        //    StreamReader reader = new StreamReader(response.GetResponseStream());
        //    string responseString = reader.ReadToEnd();

        //    //Close the response
        //    reader.Close();
        //    response.Close();


        //}


    }
}
