using ServiceGateways.Entities;
using ServiceGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.ServiceGateways
{
    public class FrontPageServiceGateway : AbstractServiceGateway, IFrontPageServiceGateway<FrontPage, int>
    {
        public FrontPage Read(int id)
        {
            HttpResponseMessage response = Client.GetAsync($"api/FrontPage/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<FrontPage>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public FrontPage Update(FrontPage t)
        {
            HttpResponseMessage response = Client.PutAsJsonAsync($"api/FrontPage", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<FrontPage>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
