﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkJwtExampleServer.Core.DTOs
{
    public class ClientDto
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public List<string> Audiences { get; set; }

    }
}
