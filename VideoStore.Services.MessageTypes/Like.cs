using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Services.MessageTypes
{
    public class Like : MessageType
    {
        public User user { get; set; }
        public Media media { get; set; }
    }
}
