using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkJwtExampleServer.Core.Entities
{
    public class FlashCard : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MotherLanguageText { get; set; }
        public string TargetLanguageText { get; set; }
        public string Caption { get; set; }
        public string PhotoPath { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
