using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Entities
{
    public class Translation
    {
        public Translation()
        {
            TranslatedTexts = new List<TranslationLanguage>();
        }

        public int Id { get; set; }
        public ICollection<TranslationLanguage> TranslatedTexts { get; set; }
    }
}
