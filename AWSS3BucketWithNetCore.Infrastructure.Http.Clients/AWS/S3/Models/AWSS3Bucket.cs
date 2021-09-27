using System;
using System.Collections.Generic;
using System.Text;

namespace AWSS3BucketWithNetCore.Infrastructure.Http.Clients.AWS.S3.Models
{
    public class AWSS3Bucket
    {
        public Configuration configuration { get; set; }
    }

    public class Configuration
    {
        public string BucketName { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
    }
}
