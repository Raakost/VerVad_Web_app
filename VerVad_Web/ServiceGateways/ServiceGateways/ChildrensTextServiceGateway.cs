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
    public class ChildrensTextServiceGateway : AbstractServiceGateway, IChildrensTextServiceGateway<ChildrensText, int>
    {
        //Create
        public ChildrensText Create(ChildrensText t)
        {
            HttpResponseMessage response = Client.PostAsJsonAsync("api/ChildrensText", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<ChildrensText>().Result;
            }
            return null;
        }

        //Read from global goal id
        public List<ChildrensText> GetTextsFromGlobalGoal(int gg_id)
        {
            HttpResponseMessage response = Client.GetAsync($"api/ChildrensText/GetTextsFromGlobalGoal/{gg_id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<ChildrensText>>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //Read
        public ChildrensText Read(int id)
        {
            HttpResponseMessage response = Client.GetAsync($"api/childrensText/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<ChildrensText>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //ReadAll
        public List<ChildrensText> ReadAll()
        {
            HttpResponseMessage response = Client.GetAsync($"api/ChildrensText").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<ChildrensText>>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //Update
        public ChildrensText Update(ChildrensText t)
        {
            HttpResponseMessage response = Client.PutAsJsonAsync($"api/ChildrensText", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<ChildrensText>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //Delete
        public bool Delete(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync($"api/ChildrensText/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<ChildrensText>().Result != null;
            }
            return false;
        }     
    }
}
