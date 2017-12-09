using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Entities
{
    public class ChildrensText
    {
        public ChildrensText()
        {
            Translation = new Translation();
        }

        public int Id { get; set; }
        public int TranslationId { get; set; }
        public string Author { get; set; }
        public Translation Translation { get; set; }

        public GlobalGoal GlobalGoal { get; set; }
        public int GlobalGoalId { get; set; }
    }
}
