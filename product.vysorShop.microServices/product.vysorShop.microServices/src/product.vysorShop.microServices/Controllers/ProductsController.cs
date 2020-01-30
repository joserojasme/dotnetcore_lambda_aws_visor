using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using product.vysorShop.microServices.Models;
using product.vysorShop.microServices.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace product.vysorShop.microServices.Controllers
{
    [Route("productodev/[controller]")]
    public class ProductsController : Controller
    {

        private IProductsServices productsServices;

        public ProductsController(IProductsServices products)
        {
            this.productsServices = products;
        }


        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {          
                var response = await this.productsServices.getAll();
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            try
            {
                if (id == null)
                {
                   return this.BadRequest("The id is required");
                }

                var response = await this.productsServices.getbyId(id.Value);
                if (response != null)
                {
                    return this.Ok(response);
                }
                else
                {
                    return this.NotFound();
                }

            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Add the specified value.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="value">Value.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Productos value)
        {
            try
            {
                if (!this.ModelState.IsValid || value == null)
                {
                    var  messages = string.Join("; ", this.ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    return BadRequest(messages);
                }

                var response =  await this.productsServices.Add(value);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody]Productos value)
        {
            try
            {
                if (!this.ModelState.IsValid || value == null)
                {
                    var messages = string.Join("; ", this.ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    return BadRequest(messages);
                }

                var response = await this.productsServices.update(value);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return this.BadRequest("The id is required");
                }

                var response = await this.productsServices.delete(id.Value);
                if (response != false)
                {
                    return this.Ok(response);
                }
                else
                {
                    return this.NotFound();
                }

            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

    
        [HttpGet("getbyname/{name}")]
        public async Task<IActionResult> GetbyName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return this.BadRequest("The name is required");
                }

                var response = await this.productsServices.getbyName(name);
                if (response != null)
                {
                    return this.Ok(response);
                }
                else
                {
                    return this.NotFound();
                }

            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpGet("getproductlistprice")]
        public async Task<IActionResult> GetProductListPrice()
        {
            try
            {

                var response = await this.productsServices.getProductListPrice();
                if (response != null)
                {
                    return this.Ok(response);
                }
                else
                {
                    return this.NotFound();
                }

            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
