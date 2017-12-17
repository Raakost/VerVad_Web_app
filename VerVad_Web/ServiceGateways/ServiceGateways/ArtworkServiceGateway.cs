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
    public class ArtworkServiceGateway : AbstractServiceGateway, IChildrensServiceGateway<Artwork, int>
    {
        //Create
        public Artwork Create(Artwork t)
        {
            HttpResponseMessage response = Client.PostAsJsonAsync("api/Artwork", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Artwork>().Result;
            }
            return null;
        }

        //Read from global goal id
        public List<Artwork> GetAllInstances(int gg_id)
        {
            HttpResponseMessage response = Client.GetAsync($"api/Artwork/GetArtworksFromGlobalGoal/{gg_id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Artwork>>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //Read
        public Artwork Read(int id)
        {
            HttpResponseMessage response = Client.GetAsync($"api/Artwork/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Artwork>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //ReadAll
        public List<Artwork> ReadAll()
        {
            HttpResponseMessage response = Client.GetAsync($"api/Artwork").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Artwork>>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //Update
        public Artwork Update(Artwork t)
        {
            HttpResponseMessage response = Client.PutAsJsonAsync($"api/Artwork", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Artwork>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //Delete
        public bool Delete(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync($"api/Artwork/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Artwork>().Result != null;
            }
            return false;
        }
    }
}
