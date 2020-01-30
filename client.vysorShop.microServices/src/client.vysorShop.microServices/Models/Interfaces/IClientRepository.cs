using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using client.vysorShop.microServices.Models;

namespace client.vysorShop.microServices.Models.Interfaces
{
    public interface IClientRepository
    {
        Task<Clientes> Add(Clientes model);
        Task<List<Clientes>> getAll();
        Task<Clientes> getbyId(int id);
        Task<Clientes> update(Clientes model);
        Task<bool> delete(int id);
        Task<List<Clientes>> getbyName(string name);
        Task<List<Clientes>> getbyDoc(string doc);
    }
}
