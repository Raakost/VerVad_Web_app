﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Entities
{
    public class AudioVideo
    {
        public int Id { get; set; }
        public int TranslationId { get; set; }
        public string AudioURL { get; set; }
        public string VideoURL { get; set; }
        public string SongArtist { get; set; }
        public string SongTitle { get; set; }
        public Translation Translation { get; set; }

        public GlobalGoal GlobalGoal { get; set; }
        public int GlobalGoalId { get; set; }
    }
}
