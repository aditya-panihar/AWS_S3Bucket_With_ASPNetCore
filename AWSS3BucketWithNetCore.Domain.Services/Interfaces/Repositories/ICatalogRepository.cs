using AWSS3BucketWithNetCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWSS3BucketWithNetCore.Domain.Services.Interfaces.Repositories
{
    public interface ICatalogRepository
    {
        Task<bool> AddCatalogAsync(Catalog catalog);
        Task<Catalog> GetCatalogByIdAsync(int catalogId);
        Task<IEnumerable<Catalog>> GetAllCatalogAsync();
        Task<bool> UpdateCatalogAsync(Catalog catalog);
        Task<bool> DeleteCatalogAsync(int catalogId);
    }
}
