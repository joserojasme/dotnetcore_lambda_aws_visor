using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cellar.vysorShop.microServices.Models.Interface
{
    public interface ICellarRepository
    {

        Task<Bodegas> AddAsync(Bodegas model);
        Task<List<Bodegas>> getAll();
        Task<Bodegas> getbyId(int id);
        Task<Bodegas> update(Bodegas model);
        Task<bool> delete(int id);
        Task<List<Bodegas>> getbyName(string name);
        Task<List<Bodegas>> getbyDoc(string doc);

    }
}
