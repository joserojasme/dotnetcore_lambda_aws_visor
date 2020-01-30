using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using transactions.vysorShop.microServices.Models;
using transactions.vysorShop.microServices.Models.Interface;
using transactions.vysorShop.microServices.Services.Interface;

namespace transactions.vysorShop.microServices.Services
{
    public class TransactionService:ITransactionService
    {
        private ITransactionRepository TransactionRepository;

        public TransactionService(ITransactionRepository transaction)
        {
            TransactionRepository = transaction;
        }
        public TransactionService()
        {
        }

        public async Task<List<TransactionResponse>> Add(List<Transacciones> model)
        {
            return await this.TransactionRepository.Add(model);
        }

        public async Task<List<Transacciones>> getAll()
        {
            return await this.TransactionRepository.getAll();
        }
    }
}
