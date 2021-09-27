using AWSS3BucketWithNetCore.Domain.Models;
using AWSS3BucketWithNetCore.Domain.Services.APIModels;
using AWSS3BucketWithNetCore.Domain.Services.Interfaces.Repositories;
using AWSS3BucketWithNetCore.Domain.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AWSS3BucketWithNetCore.Domain.Services.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<bool> AddCatalogAsync(AddCatalogRequest addCatalog)
        {
            try
            {
                Catalog objCatalog = new Catalog();
                objCatalog.Id = addCatalog.Id;
                objCatalog.Name = addCatalog.Name;
                objCatalog.CreatedDateTime = System.DateTime.Now;
                objCatalog.ModifiedDateTime = System.DateTime.Now;

                return await _catalogRepository.AddCatalogAsync(objCatalog);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CatalogResponse> GetCatalogByIdAsync(int catalogId)
        {
            CatalogResponse catalogResponse = null;

            try
            {
                Catalog catalog = await _catalogRepository.GetCatalogByIdAsync(catalogId);

                if (catalog != null)
                {
                    catalogResponse = new CatalogResponse()
                    {
                        Id = catalog.Id,
                        Name = catalog.Name,
                        CreatedDateTime = catalog.CreatedDateTime,
                        ModifiedDateTime = catalog.ModifiedDateTime
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }

            return catalogResponse;
        }

        public async Task<IEnumerable<CatalogResponse>> GetAllCatalogAsync()
        {
            List<CatalogResponse> lstCatalogResponses = null;

            try
            {
                IEnumerable<Catalog> lstCatalog = await _catalogRepository.GetAllCatalogAsync();

                if (lstCatalog != null)
                {
                    lstCatalogResponses = new List<CatalogResponse>();
                    foreach (var catalog in lstCatalog)
                    {
                        var catalogResponse = new CatalogResponse()
                        {
                            Id = catalog.Id,
                            Name = catalog.Name,
                            CreatedDateTime = catalog.CreatedDateTime,
                            ModifiedDateTime = catalog.ModifiedDateTime
                        };

                        lstCatalogResponses.Add(catalogResponse);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return lstCatalogResponses;
        }

        public async Task<bool> UpdateCatalogAsync(PutCatalogRequest putCatalog)
        {
            try
            {
                Catalog objCatalog = new Catalog();
                objCatalog.Id = putCatalog.Id;
                objCatalog.Name = putCatalog.Name;
                objCatalog.CreatedDateTime = System.DateTime.Now;
                objCatalog.ModifiedDateTime = System.DateTime.Now;

                return await _catalogRepository.UpdateCatalogAsync(objCatalog);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteCatalogAsync(int catalogId)
        {
            try
            {
                return await _catalogRepository.DeleteCatalogAsync(catalogId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
