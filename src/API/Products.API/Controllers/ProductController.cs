using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Interfaces;
using Products.Domain.DTO;
using Products.Domain.Parameters;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductParameters parameters)
        {
            try
            {
                var results = await _productAppService.Filter(parameters);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _productAppService.GetById(id);
                return result == null ? (IActionResult)NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto product)
        {
            try
            {
                await _productAppService.Add(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductDto product)
        {
            try
            {
                var success = await _productAppService.Update(id, product);
                return success ? Ok() : (IActionResult)NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productAppService.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
