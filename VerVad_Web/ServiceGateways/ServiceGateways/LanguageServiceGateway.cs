using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.ServiceGateways
{
    public class LanguageServiceGateway : AbstractServiceGateway
    {
        public List<Language> ReadAll()
        {
            HttpResponseMessage response = Client.GetAsync($"api/Language").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Language>>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
