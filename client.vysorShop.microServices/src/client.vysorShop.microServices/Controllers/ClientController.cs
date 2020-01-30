using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using client.vysorShop.microServices.Models;
using client.vysorShop.microServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace client.vysorShop.microServices.Controllers
{
    [Route("cliente/[controller]")]
    public class ClientController : Controller
    {
        private IClientServices clientServices;

        public ClientController(IClientServices client)
        {
            this.clientServices = client;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await this.clientServices.getAll();
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

                var response = await this.clientServices.getbyId(id.Value);
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
        public async Task<IActionResult> Post([FromBody]Clientes value)
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

                var response = await this.clientServices.Add(value);
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
        public async Task<ActionResult> Put([FromBody]Clientes value)
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

                var response = await this.clientServices.update(value);
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

                var response = await this.clientServices.delete(id.Value);
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

        [HttpGet("getbyname/{name}")]
        public async Task<IActionResult> GetbyName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return this.BadRequest("The name is required");
                }

                var response = await this.clientServices.getbyName(name);
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

        [HttpGet("getbydoc/{doc}")]
        public async Task<IActionResult> GetbyDoc(string doc)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(doc))
                {
                    return this.BadRequest("The doc is required");
                }

                var response = await this.clientServices.getbyDoc(doc);
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
    }
}
