using AWSS3BucketWithNetCore.Domain.Services.APIModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWSS3BucketWithNetCore.Domain.Services.Interfaces.Services
{
    public interface ICatalogService
    {
        Task<bool> AddCatalogAsync(AddCatalogRequest addCatalog);
        Task<CatalogResponse> GetCatalogByIdAsync(int catalogId);
        Task<IEnumerable<CatalogResponse>> GetAllCatalogAsync();
        Task<bool> UpdateCatalogAsync(PutCatalogRequest putCatalog);
        Task<bool> DeleteCatalogAsync(int catalogId);
    }
}
