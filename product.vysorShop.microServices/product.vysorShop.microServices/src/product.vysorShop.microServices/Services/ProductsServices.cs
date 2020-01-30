using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using product.vysorShop.microServices.Models;
using product.vysorShop.microServices.Models.Interfaces;
using product.vysorShop.microServices.Services.Interfaces;

namespace product.vysorShop.microServices.Services
{
    public class ProductsServices:IProductsServices
    {
        private IProductsRepository productsRepository;

        public ProductsServices(IProductsRepository products)
        {
            productsRepository = products;
        }
        public ProductsServices()
        {
        }

        public async Task<Productos> Add(Productos model)
        {
            return await this.productsRepository.Add(model);
        }

        public async Task<bool> delete(int id)
        {
            return await this.productsRepository.delete(id);
        }

        public async Task<List<Productos>> getAll()
        {
            return await this.productsRepository.getAll();
        }

        public async Task<Productos> getbyId(int id)
        {
            return await this.productsRepository.getbyId(id);
        }

        public async Task<List<Productos>> getbyName(string name)
        {
            return await this.productsRepository.getbyName(name);
        }

        public async Task<Productos> update(Productos model)
        {
            return await this.productsRepository.update(model);
        }

        public async Task<List<ProductosListaPrecios>> getProductListPrice()
        {
            return await this.productsRepository.getProductListPrice();
        }
    
    }
}
