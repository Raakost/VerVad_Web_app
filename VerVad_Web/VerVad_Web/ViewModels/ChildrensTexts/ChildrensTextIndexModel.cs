using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.ViewModels.ChildrensTexts
{
    public class ChildrensTextIndexModel
    {
        public List<ChildrensText> ChildrensTexts { get; set; }
        public int GlobalGoalId { get; set; }
    }
}