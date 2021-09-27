using System;
using System.Collections.Generic;
using System.Text;

namespace AWSS3BucketWithNetCore.Domain.Services.APIModels
{
    public class AddCatalogRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
