﻿using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.ViewModels.FrontPageUpdate
{
    public class FrontPageUpdateViewModel
    {
        public FrontPageUpdateViewModel()
        {
            Languages = new List<Language>();
        }
        public FrontPage Frontpage { get; set; }
        public List<Language> Languages { get; set; }
    }
}