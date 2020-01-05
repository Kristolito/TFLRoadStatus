using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using NUnit.Framework;
using System.Configuration;
using Moq;
using TFLRoadStatus;
using TFLRoadStatus.Models;

namespace Tests
{

    public class UnitTest1
    {
        private WebServiceHelper oWebServiceHelper = new WebServiceHelper();
        private ConsoleHelper oConsoleHelper = new ConsoleHelper();

        private string strValidRoad = "A1";
        private string strInvalidRoad = "T1";

        private Dictionary<HttpStatusCode, string> oDctResponce = new Dictionary<HttpStatusCode, string>();

        [SetUp]
        public void Init()
        {

        }

        [Test]

        public void ValidRoadTestRoad()
        {

            oDctResponce = oWebServiceHelper.GetRoad(strValidRoad);
            var obj = JsonConvert.DeserializeObject<List<SeverityStatus>>(oDctResponce.Values.First());
            Assert.AreEqual(strValidRoad, obj.First().displayName);
            Assert.AreEqual("Good", obj.First().statusSeverity);
            Assert.AreEqual("No Exceptional Delays", obj.First().statusSeverityDescription);
        }

        [Test]

        public void InvalidTestRoad()
        {


            oDctResponce = oWebServiceHelper.GetRoad(strInvalidRoad);
            var obj = JsonConvert.DeserializeObject<NotFoundStatus>(oDctResponce.Values.First());

            Assert.AreEqual("NotFound", obj.httpStatus);
            Assert.AreEqual("404", obj.httpStatusCode);

        }


        [Test]

        public void WhenText_Is_Changed_InvalidRoad()
        {
            string strExpectedText = $"\t The following road: { strInvalidRoad} is not a valid road.";
            oDctResponce = oWebServiceHelper.GetRoad(strInvalidRoad);
            string strInvalidResponse = oConsoleHelper.PrintInvalidRoadText(strInvalidRoad);
            Assert.AreEqual(strExpectedText, strInvalidResponse);



        }

        [Test]

        public void ValidateAppSettings()
        {

            string strvalidAppId = string.Empty;
            string strvalidAppKey = string.Empty;
            string strvalidAddress = "http://api.tfl.gov.uk/Road/";
            string strAppId = ConfigurationManager.AppSettings["AppId"];
            string strAppKey = ConfigurationManager.AppSettings["AppKey"];
            string strBaseAddress = ConfigurationManager.AppSettings["BaseAddress"];

            Assert.AreEqual(strvalidAppId, strAppId);
            Assert.AreEqual(strvalidAppKey, strAppKey);
            Assert.AreEqual(strvalidAddress, strBaseAddress);



        }

        // Mocking
        [Test]

        public void When_IsValid()
        {

            oDctResponce = oWebServiceHelper.GetRoad(strValidRoad);
            var obj = JsonConvert.DeserializeObject<List<SeverityStatus>>(oDctResponce.Values.First());
            var MockValidRoad = new Mock<List<SeverityStatus>>(obj);
            var oMockObj = new List<SeverityStatus>(MockValidRoad.Object);
            Assert.AreEqual(strValidRoad, oMockObj.First().displayName);


        }

        [Test]

        public void When_IsNotValid()
        {
            string InvalidHttpCode = "404";
            oDctResponce = oWebServiceHelper.GetRoad(strInvalidRoad);
            var obj = JsonConvert.DeserializeObject<NotFoundStatus>(oDctResponce.Values.First());
            var MockValidRoad = new Mock<NotFoundStatus>();
            var oMockObj = new NotFoundStatus
            {
                httpStatusCode = obj.httpStatusCode
            };
            Assert.AreEqual(InvalidHttpCode, oMockObj.httpStatusCode);


        }

    }
}