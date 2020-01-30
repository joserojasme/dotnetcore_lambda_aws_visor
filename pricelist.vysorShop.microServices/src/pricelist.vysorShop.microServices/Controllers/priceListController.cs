using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pricelist.vysorShop.microServices.Models;
using pricelist.vysorShop.microServices.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pricelist.vysorShop.microServices.Controllers
{
    [Route("listaprecio/[controller]")]
    public class priceListController : Controller
    {

        private IPriceListServices priceListServices;

        public priceListController(IPriceListServices priceList)
        {
            this.priceListServices = priceList;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await this.priceListServices.getAll();
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

                var response = await this.priceListServices.getbyId(id.Value);
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
                return this.BadRequest(ex.InnerException.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ListaPrecios value)
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

                var response = await this.priceListServices.Add(value);
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
        public async Task<ActionResult> Put([FromBody]ListaPrecios value)
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

                var response = await this.priceListServices.update(value);
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

                var response = await this.priceListServices.delete(id.Value);
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
                return this.BadRequest(ex.InnerException.Message);
            }
        }
    }
}
