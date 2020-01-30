using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using cellar.vysorShop.microServices.Models;

namespace cellar.vysorShop.microServices.Services.Interfaces
{
    public interface ICellarServices
    {
        Task<Bodegas> Add(Bodegas model);
        Task<List<Bodegas>> getAll();
        Task<Bodegas> getbyId(int id);
        Task<Bodegas> update(Bodegas model);
        Task<bool> delete(int id);
        Task<List<Bodegas>> getbyName(string name);
        Task<List<Bodegas>> getbyDoc(string doc);
    }
}
