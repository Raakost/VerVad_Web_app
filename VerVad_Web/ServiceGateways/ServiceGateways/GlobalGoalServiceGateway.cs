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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

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

        public List<GlobalGoal> ReadAll()
        {
            throw new NotImplementedException();
        }

        public GlobalGoal Update(GlobalGoal t)
        {
            throw new NotImplementedException();
        }
    }
}
