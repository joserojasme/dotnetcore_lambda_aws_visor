using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using transactions.vysorShop.microServices.Models;
using transactions.vysorShop.microServices.Models.Interface;

namespace transactions.vysorShop.microServices.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private Context DBcontex;
        private static int ESTADO_OK = 4;
        private static int ESTADO_FALLA = 7;

        public TransactionRepository(Context Context)
        {
            this.DBcontex = Context;
        }

        public async Task<List<TransactionResponse>> Add(List<Transacciones> model)
        {
            var list = new List<TransactionResponse>();


            foreach (Transacciones tran in model)
            {
<<<<<<< HEAD
                    var resp= AddSingle(tran);
                    list.Add(resp); 
            }

            return await Task.FromResult(list);
        }

        public  TransactionResponse AddSingle(Transacciones model)
        {
            var tran = new TransactionResponse();

            //var tran = new TransactionResponse();

            try
                {
                    model.Estado = 4;
                     this.DBcontex.Transacciones.Add(model);
                     this.DBcontex.SaveChanges();

                     tran = new TransactionResponse { idTransaction = model.IdTransacciones, Estado = model.Estado };

=======
                item.Estado = ESTADO_OK;
                Transacciones transaccion = await this.DBcontex.Transacciones
                    .Where(transacciones => transacciones.IdTransacciones == item.IdTransacciones).SingleOrDefaultAsync();

                if (transaccion == null)
                {
                    await this.DBcontex.Transacciones.AddAsync(item);
                    list.Add(new TransactionResponse { idTransaction = item.IdTransacciones, Estado = item.Estado });
>>>>>>> 5bd0a484ab66b8891ef2bd3fc9d91e505f7d2e2a
                }
                else
                {
<<<<<<< HEAD
                    model.Estado = 7;
                    tran = new TransactionResponse { idTransaction = model.IdTransacciones, Estado = model.Estado };
=======
                    list.Add(new TransactionResponse { idTransaction = item.IdTransacciones, Estado = ESTADO_FALLA });
>>>>>>> 5bd0a484ab66b8891ef2bd3fc9d91e505f7d2e2a
                }

<<<<<<< HEAD

            return  tran;
=======
            await this.DBcontex.SaveChangesAsync();
            return await Task.FromResult(list);
>>>>>>> 5bd0a484ab66b8891ef2bd3fc9d91e505f7d2e2a
        }

        public async Task<List<Transacciones>> getAll()
        {
            var query = await this.DBcontex.Transacciones.ToListAsync();

            return await Task.FromResult(query);
        }
    }
}