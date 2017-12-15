using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Entities
{
    public class Artwork
    {
        public Artwork()
        {
            Translation = new Translation();
        }

        public int Id { get; set; }
        public int TranslationId { get; set; }
        public string ImgUrl { get; set; }
        public string Artist { get; set; }
        public Translation Translation { get; set; }
        public GlobalGoal GlobalGoal { get; set; }
        public int GlobalGoalId { get; set; }

    }
}
