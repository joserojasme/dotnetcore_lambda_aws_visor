using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pricelist.vysorShop.microServices.Models;

namespace pricelist.vysorShop.microServices.Services.Interfaces
{
    public interface IPriceListServices
    {
        Task<ListaPrecios> Add(ListaPrecios model);
        Task<List<ListaPrecios>> getAll();
        Task<ListaPrecios> getbyId(int id);
        Task<ListaPrecios> update(ListaPrecios model);
        Task<bool> delete(int id);
    }
}
