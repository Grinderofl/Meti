using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MetiDomain.Entities.Base
{
    [DataContract]
    public abstract class DualIdentity
    {
        protected DualIdentity()
        {
            UUID = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public Guid UUID { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
