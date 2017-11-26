using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;


namespace RTP.TESWebServer
{
    /// <summary>
    /// Summary description for GetAvailabilityStatus
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public  class GetAvailabilityStatus : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetStatus()
        {
            //string jsonString = string.Empty;
            var availabilityStatuses = DataSnapshot.AvailabilitySettingsToClass();
            var variableList = availabilityStatuses.Select(e => e.Variable).ToList();
            var dt = DataSnapshot.GetSnapshot(variableList);
            Context.Response.Write(JsonConvert.SerializeObject(dt));
        }

        [WebMethod]

        public void GetAvailabilityVariable()
        {
            var availabilityStatuses = DataSnapshot.AvailabilitySettingsToClass();
            Context.Response.Write(JsonConvert.SerializeObject(availabilityStatuses));
        }

        [WebMethod]
        public void GetSettingValue()
        {
            //string jsonString = string.Empty;
            var engineerVariables = DataSnapshot.EngrSettingsToClass();
            var variableList = engineerVariables.Select(e => e.Variable).ToList();
            var dt = DataSnapshot.GetSnapshot(variableList);
            Context.Response.Write(JsonConvert.SerializeObject(dt));
        }

        [WebMethod]

        public void GetEngineerSettingVariable()
        {
            var engineerVariables = DataSnapshot.EngrSettingsToClass();
            Context.Response.Write(JsonConvert.SerializeObject(engineerVariables));
        }

    }
}
