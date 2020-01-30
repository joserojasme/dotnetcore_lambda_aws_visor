using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using client.vysorShop.microServices.Models.Interfaces;
using client.vysorShop.microServices.Models;
using Microsoft.EntityFrameworkCore;

namespace client.vysorShop.microServices.Data.Repositories
{
    public class ClientRepository:IClientRepository
    {
        private dondiegoDBContext DBcontex;

        public ClientRepository(dondiegoDBContext Context)
        {
            this.DBcontex = Context;
        }


        public async Task<Clientes> Add(Clientes model)
        {
            model.FechaCreacion = DateTime.UtcNow;
            model.IdEstado = 1;
            this.DBcontex.Clientes.Add(model);
            this.DBcontex.SaveChanges();
            return await Task.FromResult(model);
        }



        public async Task<bool> delete(int id)
        {
            var result = this.DBcontex.Clientes.SingleOrDefault(b => b.Id == id);

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

        public async Task<List<Clientes>> getAll()
        {

            var query = (from p in this.DBcontex.Clientes   
                         where p.IdEstado == 1
                         select p).ToList<Clientes>();

            return await Task.FromResult(query);
        }

        public async Task<Clientes> getbyId(int id)
        {
            var query = (from p in this.DBcontex.Clientes
                         where p.Id == id & p.IdEstado == 1
                         select p).FirstOrDefault<Clientes>();

            return await Task.FromResult(query);

        }

        public async Task<List<Clientes>> getbyName(string name)
        {
            var query = (from p in this.DBcontex.Clientes
                         where p.Nombre.Contains(name) && p.IdEstado == 1
                         select p).ToList<Clientes>();

            return await Task.FromResult(query);
        }

        public async Task<List<Clientes>> getbyDoc(string doc)
        {
            var query = (from p in this.DBcontex.Clientes
                         where p.Identificacion.Contains(doc) && p.IdEstado == 1
                         select p).ToList<Clientes>();

            return await Task.FromResult(query);
        }


        public async Task<Clientes> update(Clientes model)
        {
            var result = this.DBcontex.Clientes.SingleOrDefault(b => b.Id == model.Id && b.IdEstado == 1);

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
