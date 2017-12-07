﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Entities
{
    public class GlobalGoal
    {
        public GlobalGoal()
        {
            Translation = new Translation();
        }
        public int Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string ImgURL { get; set; }

        public AudioVideo AudioVideo { get; set; }
        public List<LandArt> LandArts { get; set; }
        public List<Artwork> Artworks { get; set; }        
        public List<ChildrensText> ChildrensTexts { get; set; }

        public int TranslationId { get; set; }
        public Translation Translation { get; set; }
        public bool IsPublished { get; set; }


    }
}
