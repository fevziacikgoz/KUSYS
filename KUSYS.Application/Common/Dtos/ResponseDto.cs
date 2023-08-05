using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Application.Common.Dtos
{
    public class ResponseDto
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
        public List<ErrorDto> Errors { get; set; }
    }
}
