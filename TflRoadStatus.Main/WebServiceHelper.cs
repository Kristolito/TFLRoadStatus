using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;


namespace TFLRoadStatus
{
    public class WebServiceHelper
    {


        private HttpStatusCode StatusCode { get; set; }
        private string AppId = System.Configuration.ConfigurationManager.AppSettings["AppId"];
        private string APIkey = System.Configuration.ConfigurationManager.AppSettings["AppKey"];
        private string BaseAddress = System.Configuration.ConfigurationManager.AppSettings["BaseAddress"];

        public Dictionary<HttpStatusCode, string> GetRoad(string road)
        {
            var dctResponce = new Dictionary<HttpStatusCode, string>();

            using (var httpClient = new HttpClient())
            {
                var requestUrl = GenerateURL(road);

                var httpContent = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                HttpResponseMessage response = httpClient.SendAsync(httpContent).Result;

                StatusCode = response.StatusCode;

                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NotFound)
                {

                    dctResponce.Add(StatusCode, response.Content.ReadAsStringAsync().Result);

                }

                if (!dctResponce.ContainsKey(StatusCode))
                {
                    dctResponce.Add(StatusCode, response.Content.ReadAsStringAsync().Result);
                }

            }

            return dctResponce;
        }

        private string GenerateURL(string road)
        {
            return string.Format(BaseAddress + "{0}?app_id={1}&app_key={2}", road, AppId, APIkey);
        }


    }




}
