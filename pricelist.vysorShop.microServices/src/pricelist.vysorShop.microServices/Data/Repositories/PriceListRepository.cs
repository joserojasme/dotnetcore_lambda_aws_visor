using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pricelist.vysorShop.microServices.Models;
using pricelist.vysorShop.microServices.Models.Interfaces;


namespace pricelist.vysorShop.microServices.Data.Repositories
{
    public class PriceListRepository : IPriceListRepository
    {

        private dondiegoDBContext DBcontex;

        public PriceListRepository(dondiegoDBContext Context)
        {
            this.DBcontex = Context;
        }



        public async Task<ListaPrecios> Add(ListaPrecios model)
        {
            model.FechaCreacion = DateTime.UtcNow;
            model.IdEstado = 1;
            this.DBcontex.ListaPrecios.Add(model);
            this.DBcontex.SaveChanges();
            return await Task.FromResult(model);
        }

        public async Task<bool> delete(int id)
        {
            var result = this.DBcontex.ListaPrecios.SingleOrDefault(b => b.Id == id);

            if (result != null)
            {
                result.IdEstado = 0;
                this.DBcontex.SaveChanges();
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<List<ListaPrecios>> getAll()
        {
            var query = (from p in this.DBcontex.ListaPrecios
                         where p.IdEstado == 1
                         select p).ToList<ListaPrecios>();

            return await Task.FromResult(query);
        }

        public async Task<ListaPrecios> getbyId(int id)
        {
            var query = (from p in this.DBcontex.ListaPrecios
                         where p.Id == id & p.IdEstado == 1
                         select p).FirstOrDefault<ListaPrecios>();

            return await Task.FromResult(query);
        }

        public async Task<List<ListaPrecios>> getbyName(string name)
        {
            var query = (from p in this.DBcontex.ListaPrecios
                         where p.Nombre.Contains(name) && p.IdEstado == 1
                         select p).ToList<ListaPrecios>();

            return await Task.FromResult(query);
        }

        public async Task<ListaPrecios> update(ListaPrecios model)
        {
            var result = this.DBcontex.ListaPrecios.SingleOrDefault(b => b.Id == model.Id && b.IdEstado == 1);

            if (result != null)
            {
                model.IdEstado = 1;
                this.DBcontex.Entry(result).CurrentValues.SetValues(model);
                this.DBcontex.SaveChanges();
                return await Task.FromResult(model);
            }
            else
            {
                return await Task.FromResult(result);
            }

        }

       

      
    }
}
