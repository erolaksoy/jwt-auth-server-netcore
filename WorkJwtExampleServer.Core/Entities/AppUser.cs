using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WorkJwtExampleServer.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public virtual IEnumerable<FlashCard> FlashCards { get; set; }
    }
}
