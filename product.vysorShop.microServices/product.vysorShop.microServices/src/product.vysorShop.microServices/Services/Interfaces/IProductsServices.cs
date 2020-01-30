using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using product.vysorShop.microServices.Models;

namespace product.vysorShop.microServices.Services.Interfaces
{
    public interface IProductsServices
    {
        Task<Productos> Add(Productos model);
        Task<List<Productos>> getAll();
        Task<Productos> getbyId(int id);
        Task<List<Productos>> getbyName(string name);
        Task<Productos> update(Productos model);
        Task<bool> delete(int id);
        Task<List<ProductosListaPrecios>> getProductListPrice();
    }
}
