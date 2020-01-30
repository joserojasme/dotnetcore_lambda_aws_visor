using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace product.vysorShop.microServices.Models.Interfaces
{
    public interface IProductsRepository
    {
        Task<Productos> Add(Productos model);
        Task<List<Productos>> getAll();
        Task<Productos> getbyId(int id);
        Task<Productos> update(Productos model);
        Task<bool> delete(int id);
        Task<List<Productos>> getbyName(string name);
        Task<List<Productos>> getbyPriceList();
        Task<List<ProductosListaPrecios>> getProductListPrice();


    }
}
