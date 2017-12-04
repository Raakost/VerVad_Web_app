using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerVad_Web.Models
{
    public class Translation
    {
        public int Id { get; set; }
        public ICollection<TranslationLanguage> TranslatedTexts { get; set; }
    }
}
