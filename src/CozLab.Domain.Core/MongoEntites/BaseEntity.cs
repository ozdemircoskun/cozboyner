using System;
using System.Collections.Generic;
using System.Text;

namespace CozLab.Domain.Core.MongoEntites
{
    public class BaseEntity : Document
    {
        public string CreateUserId { get; set; }
        public DateTime CreateUserTime { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime? UpdateUserTime { get; set; }
        public string GcRecId { get; set; }

    }
}
