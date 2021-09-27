using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AWSS3BucketWithNetCore.Domain.Models
{
    [DataContract]
    public class Catalog
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [DataMember(Name = "ModifiedDateTime")]
        public DateTime ModifiedDateTime { get; set; }

    }
}
