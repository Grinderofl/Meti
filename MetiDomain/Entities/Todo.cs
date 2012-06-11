using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetiDomain.Entities.Base;

namespace MetiDomain.Entities
{
    public class Todo : DualIdentity
    {
        public string Name { get; set; }
        public string Contents { get; set; }
        public DateTime ExpiresOn { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
