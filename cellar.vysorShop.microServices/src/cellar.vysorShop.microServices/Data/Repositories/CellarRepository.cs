using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cellar.vysorShop.microServices.Models;
using cellar.vysorShop.microServices.Models.Interface;

namespace cellar.vysorShop.microServices.Data.Repositories
{
    public class CellarRepository:ICellarRepository
    {
        private Context DBcontex;

        public CellarRepository(Context Context)
        {
            this.DBcontex = Context;
        }

        public async Task<Bodegas> AddAsync(Bodegas model)
        {
            model.FechaCreacion = DateTime.UtcNow;
            model.IdEstado = 1;
            this.DBcontex.Bodegas.Add(model);
            this.DBcontex.SaveChanges();
            return await Task.FromResult(model);
        }

        public async Task<bool> delete(int id)
        {
            var result = this.DBcontex.Bodegas.SingleOrDefault(b => b.Id == id);

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

        public async Task<List<Bodegas>> getAll()
        {
            var query = (from p in this.DBcontex.Bodegas
                         where p.IdEstado == 1
                         select p).ToList<Bodegas>();

            return await Task.FromResult(query);
        }

        public Task<List<Bodegas>> getbyDoc(string doc)
        {
            throw new NotImplementedException();
        }

        public async Task<Bodegas> getbyId(int id)
        {
            var query = (from p in this.DBcontex.Bodegas
                         where p.Id == id & p.IdEstado == 1
                         select p).FirstOrDefault<Bodegas>();

            return await Task.FromResult(query);
        }

        public async Task<List<Bodegas>> getbyName(string name)
        {
            var query = (from p in this.DBcontex.Bodegas
                         where p.Nombre.Contains(name) && p.IdEstado == 1
                         select p).ToList<Bodegas>();

            return await Task.FromResult(query);
        }

        public async Task<Bodegas> update(Bodegas model)
        {
            var result = this.DBcontex.Bodegas.SingleOrDefault(b => b.Id == model.Id && b.IdEstado == 1);

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
