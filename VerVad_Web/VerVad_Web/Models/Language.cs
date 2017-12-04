using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerVad_Web.Models
{
    public class Language
    {
        public string ISO { get; set; }
        public string Country { get; set; }
        public virtual List<TranslationLanguage> Translations { get; set;}
    }
}
