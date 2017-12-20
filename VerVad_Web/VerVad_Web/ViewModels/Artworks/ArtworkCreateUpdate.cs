using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.ViewModels.Artworks
{
    public class ArtworkCreateUpdate
    {
        public ArtworkCreateUpdate()
        {
            Languages = new List<Language>();
        }
        public Artwork Artwork { get; set; }
        public List<Language> Languages { get; set; }
        public int GlobalGoalId { get; set; }
    }
}