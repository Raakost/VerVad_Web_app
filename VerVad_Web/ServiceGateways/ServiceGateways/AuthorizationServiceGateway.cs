using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json.Linq;
using ServiceGateways.Facade;
using ServiceGateways.Interfaces;

namespace ServiceGateways.ServiceGateways
{
    public class AuthorizationServiceGateway:AbstractServiceGateway, IAuthorizationServiceGateway
    {
        public HttpResponseMessage Login(string email, string password)
        {
            //Setup login data
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("password", password)
            });

            //Request token
            HttpResponseMessage response = Client.PostAsync("/token", formContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseJson = response.Content.ReadAsStringAsync().Result;
                var jObject = JObject.Parse(responseJson);
                string token = jObject.GetValue("access_token").ToString();
                HttpContext.Current.Session["token"] = token;
            }
            return response;
        }
    }
}