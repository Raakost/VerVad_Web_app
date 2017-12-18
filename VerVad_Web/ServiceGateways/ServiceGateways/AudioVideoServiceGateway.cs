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
    public class AudioVideoServiceGateway : AbstractServiceGateway, IChildrensServiceGateway<AudioVideo, int>
    {
        //Create
        public AudioVideo Create(AudioVideo t)
        {
            AddAuthorizationHeader();
            HttpResponseMessage response = Client.PostAsJsonAsync("api/AudioVideo", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<AudioVideo>().Result;
            }
            return null;
        }

        //Delete
        public bool Delete(int id)
        {
            AddAuthorizationHeader();
            HttpResponseMessage response = Client.DeleteAsync($"api/AudioVideo/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<AudioVideo>().Result != null;
            }
            return false;
        }

        //Read from global goal id
        public List<AudioVideo> GetAllInstances(int gg_id)
        {
            throw new NotImplementedException();
        }

        //Read
        public AudioVideo Read(int id)
        {
            AddAuthorizationHeader();
            HttpResponseMessage response = Client.GetAsync($"api/AudioVideo/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<AudioVideo>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        //ReadAll
        public List<AudioVideo> ReadAll()
        {
            throw new NotImplementedException();
        }

        //Update
        public AudioVideo Update(AudioVideo t)
        {
            AddAuthorizationHeader();
            HttpResponseMessage response = Client.PutAsJsonAsync($"api/AudioVideo", t).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<AudioVideo>().Result;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
