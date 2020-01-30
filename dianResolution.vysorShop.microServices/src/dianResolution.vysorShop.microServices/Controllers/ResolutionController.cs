using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dianResolution.vysorShop.microServices.Models;
using dianResolution.vysorShop.microServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dianResolution.vysorShop.microServices.Controllers
{
    [Route("resoluciondev/[controller]")]
    public class ResolutionController : Controller
    {
        private IResolutionServices ResolutionServices;

        public ResolutionController(IResolutionServices services)
        {
            this.ResolutionServices = services;
        }


        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await this.ResolutionServices.getAll();
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

        // GET api/values/5 consulta por punto de venta
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            try
            {
                if (id == null)
                {
                    return this.BadRequest("The id is required");
                }

                var response = await this.ResolutionServices.getbyId(id.Value);
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
        public async Task<IActionResult> Post([FromBody]ResolucionDian value)
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

                var response = await this.ResolutionServices.Add(value);
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
        public async Task<ActionResult> Put([FromBody]ResolucionDian value)
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

                var response = await this.ResolutionServices.update(value);
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

    }
}
