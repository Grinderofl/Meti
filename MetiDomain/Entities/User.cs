using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using MetiDomain.Entities.Base;

namespace MetiDomain.Entities
{
    [DataContract]
    public class User : DualIdentity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Email { get; set; }

        public short Status { get; set; }

        public virtual ICollection<Todo> TodoItems { get; set; }
        public virtual ICollection<Session> Sessions { get; set; } 
    }
}
