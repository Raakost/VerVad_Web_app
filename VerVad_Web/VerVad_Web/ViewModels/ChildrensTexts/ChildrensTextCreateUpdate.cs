using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.ViewModels.ChildrensTexts
{
    public class ChildrensTextCreateUpdate
    {
        public ChildrensTextCreateUpdate()
        {
            Languages = new List<Language>();
        }
        public ChildrensText ChildrensText { get; set; }
        public List<Language> Languages { get; set; }
        public int GlobalGoalId { get; set; }
    }
}