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
    public class LandArtServiceGateway : AbstractServiceGateway, IChildrensServiceGateway<LandArt, int>
    {
        //Create
        public LandArt Create(LandArt t)
        {
            HttpResponseMessage response = Client.PostAsJsonAsync("api/LandArt", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<LandArt>().Result;
            }
            return null;
        }

        //Delete
        public bool Delete(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync($"api/LandArt/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<LandArt>().Result != null;
            }
            return false;
        }

        //Read from Global goal id
        public List<LandArt> GetAllInstances(int gg_id)
        {
            HttpResponseMessage response = Client.GetAsync($"api/Landart/GetLandartFromGlobalGoal/{gg_id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<LandArt>>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //Read
        public LandArt Read(int id)
        {
            HttpResponseMessage response = Client.GetAsync($"api/LandArt/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<LandArt>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //ReadAll
        public List<LandArt> ReadAll()
        {
            HttpResponseMessage response = Client.GetAsync($"api/LandArt").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<LandArt>>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //Update
        public LandArt Update(LandArt t)
        {
            HttpResponseMessage response = Client.PutAsJsonAsync($"api/LandArt", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<LandArt>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
