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
        private IChildrensTextServiceGateway<ChildrensText, int> _childrensTextGateway;
        private IAuthorizationServiceGateway _authGateway;
        private IChildrensServiceGateway<LandArt, int> _landArtGateway;
        private IChildrensServiceGateway<Artwork, int> _artworkGateway;
        private IChildrensServiceGateway<AudioVideo, int> _audioVideoGateway; 


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

        public IChildrensTextServiceGateway<ChildrensText, int> GetChildrensTextServiceGateway()
        {
            return _childrensTextGateway ?? (_childrensTextGateway = new ChildrensTextServiceGateway());
        }

        public IChildrensServiceGateway<LandArt, int> GetLandArtServiceGateway()
        {
            return _landArtGateway ?? (_landArtGateway = new LandArtServiceGateway());
        }

        public IChildrensServiceGateway<Artwork, int> GetArtworkServiceGateway()
        {
            return _artworkGateway ?? (_artworkGateway = new ArtworkServiceGateway());
        }

        public IChildrensServiceGateway<AudioVideo, int> GetAudioVideoServiceGateway()
        {
            return _audioVideoGateway ?? (_audioVideoGateway = new AudioVideoServiceGateway());
        }

        public IAuthorizationServiceGateway GetAuthGateway()
        {
            return _authGateway ?? (_authGateway = new AuthorizationServiceGateway());
        }
    }
}
