using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkJwtExampleServer.Core.Entities
{
    public class UserRefreshToken : IEntity
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public string UserId { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }


    }
}
