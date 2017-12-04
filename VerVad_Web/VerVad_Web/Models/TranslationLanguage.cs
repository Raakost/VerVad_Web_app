using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerVad_Web.Models
{
    public class TranslationLanguage
    {
        public string LanguageISO { get; set; }
        public Language Language { get; set; }
        public int TranslationId { get; set; }
        public Translation Translation { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
