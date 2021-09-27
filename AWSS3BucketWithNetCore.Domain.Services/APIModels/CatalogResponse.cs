using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AWSS3BucketWithNetCore.Domain.Services.APIModels
{
    public class CatalogResponse
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
