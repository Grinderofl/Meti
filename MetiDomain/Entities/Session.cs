using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetiDomain.Entities.Base;

namespace MetiDomain.Entities
{
    public class Session : DualIdentity
    {
        public string IP { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
