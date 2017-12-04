using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerVad_Web.Models
{
    public class FrontPage
    {
        public int Id { get; set; }
        public string ImgURL { get; set; }
        public int TranslationId { get; set; }
        public Translation Translation { get; set; }
    }
}
