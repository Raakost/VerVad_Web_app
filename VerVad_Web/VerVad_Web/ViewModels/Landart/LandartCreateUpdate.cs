using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.ViewModels.Landart
{
    public class LandartCreateUpdate
    {
        public LandArt LandArt { get; set; }
        public List<Language> Languages { get; set; }
        public int GlobalGoalId { get; set; }
    }
}