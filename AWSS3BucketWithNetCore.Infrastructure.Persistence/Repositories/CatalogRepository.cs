using AWSS3BucketWithNetCore.Domain.Models;
using AWSS3BucketWithNetCore.Domain.Services.Interfaces.Repositories;
using AWSS3BucketWithNetCore.Infrastructure.Http.Clients.AWS.S3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AWSS3BucketWithNetCore.Infrastructure.Persistence.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        public readonly FilesRepositoryClient _filesRepositoryClient;

        public CatalogRepository(FilesRepositoryClient filesRepositoryClient)
        {
            _filesRepositoryClient = filesRepositoryClient;
        }

        public async Task<bool> AddCatalogAsync(Catalog objCatalog)
        {
            try
            {
                int fileName = objCatalog.Id;
                var jsonString = JsonConvert.SerializeObject(objCatalog);
                return await _filesRepositoryClient.UploadFileAsync(fileName, jsonString);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Catalog> GetCatalogByIdAsync(int catalogId)
        {
            Catalog catalog = null;
            try
            {
                Stream stream = await _filesRepositoryClient.GetFileAsync(catalogId.ToString() + ".json");

                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();

                catalog = JsonConvert.DeserializeObject<Catalog>(text);
            }
            catch (Exception)
            {

                throw;
            }
            
            return catalog;
        }

        public async Task<IEnumerable<Catalog>> GetAllCatalogAsync()
        {
            List<Catalog> lstCatalog = new List<Catalog>();
            try
            {
                List<string> files = await _filesRepositoryClient.GetFilesListAsync();
                
                foreach (var fileName in files)
                {
                    Stream stream = await _filesRepositoryClient.GetFileAsync(fileName);

                    StreamReader reader = new StreamReader(stream);
                    string text = reader.ReadToEnd();

                    Catalog catalog = JsonConvert.DeserializeObject<Catalog>(text);
                    lstCatalog.Add(catalog);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return lstCatalog;
        }

        public async Task<bool> UpdateCatalogAsync(Catalog objCatalog)
        {
            try
            {
                int fileName = objCatalog.Id;
                var jsonString = JsonConvert.SerializeObject(objCatalog);
                return await _filesRepositoryClient.UpdateFileAsync(fileName, jsonString);
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
                return await _filesRepositoryClient.DeleteFileAsync(catalogId.ToString() + ".json");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
