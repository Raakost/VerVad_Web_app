using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.ViewModels.Artworks
{
    public class ArtworkIndexModel
    {
        public ArtworkIndexModel()
        {
            Artworks = new List<Artwork>();
        }

        public List<Artwork> Artworks { get; set; }
        public int GlobalGoalId { get; set; }
    }
}