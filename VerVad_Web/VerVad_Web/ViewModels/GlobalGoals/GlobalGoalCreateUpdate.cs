using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.ViewModels.GlobalGoals
{
    public class GlobalGoalCreateUpdate 
    {
        public GlobalGoal GlobalGoal { get; set; }
        public List<Language> Languages { get; set; }   
    }
}