using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pricelist.vysorShop.microServices.Models.Interfaces
{
    public interface IPriceListRepository
    {
        Task<ListaPrecios> Add(ListaPrecios model);
        Task<List<ListaPrecios>> getAll();
        Task<ListaPrecios> getbyId(int id);
        Task<ListaPrecios> update(ListaPrecios model);
        Task<bool> delete(int id);
    }
}
