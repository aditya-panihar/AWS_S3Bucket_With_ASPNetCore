using AWSS3BucketWithNetCore.Domain.Services.APIModels;
using AWSS3BucketWithNetCore.Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSS3BucketWithNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCatalogAsync(AddCatalogRequest catalogRequest)
        {
            try
            {
                var response = await _catalogService.AddCatalogAsync(catalogRequest);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCatalogAsync()
        {
            try
            {
                var response = await _catalogService.GetAllCatalogAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCatalogByIdAsync(int id)
        {
            try
            {
                var response = await _catalogService.GetCatalogByIdAsync(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCatalogAsync(PutCatalogRequest catalogRequest)
        {
            try
            {
                var response = await _catalogService.UpdateCatalogAsync(catalogRequest);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCatalogAsync(int id)
        {
            try
            {
                var response = await _catalogService.DeleteCatalogAsync(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
