using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkJwtExampleServer.Core.DTOs
{
    public class FlashCardDto
    {
        public string Name { get; set; }
        public string MotherLanguageText { get; set; }
        public string TargetLanguageText { get; set; }
        public string Caption { get; set; }
        public string PhotoPath { get; set; }
        public string AppUserId { get; set; }
    }
}
