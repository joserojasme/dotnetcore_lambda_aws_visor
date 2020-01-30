using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using transactions.vysorShop.microServices.Models;

namespace transactions.vysorShop.microServices.Services.Interface
{
    public interface ITransactionService
    {
        Task<List<TransactionResponse>> Add(List<Transacciones> model);
        Task<List<Transacciones>> getAll();
    }
}
