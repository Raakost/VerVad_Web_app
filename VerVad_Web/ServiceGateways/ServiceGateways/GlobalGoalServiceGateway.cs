using ServiceGateways.Interfaces;
using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.ServiceGateways
{
    public class GlobalGoalServiceGateway : AbstractServiceGateway, IServiceGateway<GlobalGoal, int>
    {
        //Create
        public GlobalGoal Create(GlobalGoal t)
        {
            //AddAuthorizationHeader();
            HttpResponseMessage response = Client.PostAsJsonAsync("api/GlobalGoal", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<GlobalGoal>().Result;
            }
            return null;
        }

        //Delete
        public bool Delete(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync($"api/GlobalGoal/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<GlobalGoal>().Result != null;
            }
            return false;
        }

        //Read
        public GlobalGoal Read(int id)
        {
            HttpResponseMessage response = Client.GetAsync($"api/GlobalGoal/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<GlobalGoal>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //ReadAll
        public List<GlobalGoal> ReadAll()
        {
            HttpResponseMessage response = Client.GetAsync($"api/GlobalGoal").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<GlobalGoal>>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //Update
        public GlobalGoal Update(GlobalGoal t)
        {
            HttpResponseMessage response = Client.PutAsJsonAsync($"api/GlobalGoal", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<GlobalGoal>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
