using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.ViewModels.Landart
{
    public class LandArtIndexModel
    {
        public List<LandArt> LandArts { get; set; }
        public int GlobalGoalId { get; set; }
    }
}