using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace transactions.vysorShop.microServices.Models.Interface
{
    public interface ITransactionRepository
    {
        Task<List<TransactionResponse>> Add(List<Transacciones> model);
        Task<List<Transacciones>> getAll();
    }
}
