using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Services.MessageTypes
{
    class Recommendation
    {
        public int Score {get; set;}
        public Media media { get; set; }
        public Like like { get; set; }
    }
}
