using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Entities
{
    public class FrontPage
    {
        public FrontPage()
        {
            Translation = new Translation();
        }

        public int Id { get; set; }
        public string ImgURL { get; set; }
        public int TranslationId { get; set; }
        public Translation Translation { get; set; }
    }
}
