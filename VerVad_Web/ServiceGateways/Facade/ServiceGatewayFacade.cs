﻿using ServiceGateways.Interfaces;
using ServiceGateways.Entities;
using ServiceGateways.ServiceGateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Facade
{
    public class ServiceGatewayFacade
    {
        private IServiceGateway<GlobalGoal, int> _globalGoalGateway;
        private ILanguageServiceGateway<Language> _languageGateway;
        private IFrontPageServiceGateway<FrontPage, int> _frontPageGateway;
        public IServiceGateway<GlobalGoal, int> GetGlobalGoalServiceGateway()
        {
            return _globalGoalGateway ?? (_globalGoalGateway = new GlobalGoalServiceGateway());
        }

        public ILanguageServiceGateway<Language> GetLanguageServiceGateway()
        {
            return _languageGateway ?? (_languageGateway = new LanguageServiceGateway());
        }

        public IFrontPageServiceGateway<FrontPage, int> GetFrontPageServiceGateway()
        {
            return _frontPageGateway ?? (_frontPageGateway = new FrontPageServiceGateway());
        }
    }
}
