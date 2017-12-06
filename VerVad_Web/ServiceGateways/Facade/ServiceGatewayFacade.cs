using ServiceGateways.Interfaces;
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
        private LanguageServiceGateway _languageServiceGateway;
        public IServiceGateway<GlobalGoal, int> GetGlobalGoalServiceGateway()
        {
            return _globalGoalGateway ?? (_globalGoalGateway = new GlobalGoalServiceGateway());
        }

        public LanguageServiceGateway GetLanguageServiceGateway()
        {
            return _languageServiceGateway ?? (_languageServiceGateway = new LanguageServiceGateway());
        }
    }
}
