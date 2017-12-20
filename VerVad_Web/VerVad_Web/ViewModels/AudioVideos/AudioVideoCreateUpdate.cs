using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.ViewModels.AudioVideos
{
    public class AudioVideoCreateUpdate
    {
        public AudioVideoCreateUpdate()
        {
            Languages = new List<Language>();
        }
        public AudioVideo AudioVideo { get; set; }
        public List<Language> Languages { get; set; }        
        public bool IsCreate { get; set; }
    }
}