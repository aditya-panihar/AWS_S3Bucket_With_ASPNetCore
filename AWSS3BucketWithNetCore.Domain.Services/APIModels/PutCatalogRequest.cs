using System;
using System.Collections.Generic;
using System.Text;

namespace AWSS3BucketWithNetCore.Domain.Services.APIModels
{
    public class PutCatalogRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
