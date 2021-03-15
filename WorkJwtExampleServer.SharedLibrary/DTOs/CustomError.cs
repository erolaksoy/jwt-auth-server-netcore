using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkJwtExampleServer.SharedLibrary.DTOs
{
    public class CustomError
    {
        public List<string> Errors { get; set; } = new List<string>();
        public bool IsShow { get; set; }

        public CustomError(string error, bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }

        public CustomError(List<string> errors, bool isShow)
        {
            Errors.AddRange(errors);
            IsShow = isShow;
        }
    }
}
