using CloudinaryDotNet.Actions;
using ServiceGateways.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_Web.ViewModels.GlobalGoals
{
    public class GlobalGoalCreateUpdate 
    {
        public GlobalGoalCreateUpdate()
        {
            Languages = new List<Language>();
            Folders = new List<Folder>();
        }
        public GlobalGoal GlobalGoal { get; set; }
        public List<Language> Languages { get; set; }
        public List<Folder> Folders { get; set; }
    }
}