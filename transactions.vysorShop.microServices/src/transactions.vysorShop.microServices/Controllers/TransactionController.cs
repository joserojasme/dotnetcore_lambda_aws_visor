using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using transactions.vysorShop.microServices.Models;
using transactions.vysorShop.microServices.Services.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace transactions.vysorShop.microServices.Controllers
{
    [Route("transacciones/[controller]")]
    public class TransactionController : Controller
    {
        private ITransactionService TransactionServices;

        public TransactionController(ITransactionService transaction)
        {
            this.TransactionServices = transaction;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await this.TransactionServices.getAll();
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

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]List<Transacciones> value)
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

                var response = await this.TransactionServices.Add(value);
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
    }
}
