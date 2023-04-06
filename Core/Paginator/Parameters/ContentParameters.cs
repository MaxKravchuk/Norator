using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Paginator.Parameters
{
    public class ContentParameters : ElementParameters
    {
        public string? FilterParam { get; init; }
        public string? ActorName { get; set; }
    }
}
