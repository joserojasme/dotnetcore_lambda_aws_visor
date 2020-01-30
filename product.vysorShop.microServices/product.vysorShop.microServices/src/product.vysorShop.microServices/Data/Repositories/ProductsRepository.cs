using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using product.vysorShop.microServices.Models;
using product.vysorShop.microServices.Models.Interfaces;


namespace product.vysorShop.microServices.Data.Repositories
{
    public class ProductsRepository: IProductsRepository
    {

        private Context DBcontex;

        public ProductsRepository(Context Context )
        {
            this.DBcontex = Context;
        }

        public async Task<Productos> Add(Productos model)
        {
            model.FechaCreacion = DateTime.UtcNow;
            model.IdEstado = 1;
            this.DBcontex.Productos.Add(model);
            this.DBcontex.SaveChanges();
            return await Task.FromResult(model);

        }

        public async Task<bool> delete(int id)
        {
            var result = this.DBcontex.Productos.SingleOrDefault(b => b.Id == id  );

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
             

        public async Task<List<Productos>> getAll()
        {
            var query = (from p in this.DBcontex.Productos
                         where p.IdEstado == 1
                         select p).ToList<Productos>();

            return await Task.FromResult(query);
        }

        public async Task<Productos> getbyId(int id)
        {
            var query = (from p in this.DBcontex.Productos
                           where p.Id == id & p.IdEstado == 1
                           select p).FirstOrDefault<Productos>();

            return await Task.FromResult(query);
        }

        public async Task<List<Productos>> getbyName(string name)
        {
            var query = (from p in this.DBcontex.Productos
                           where p.Nombre.Contains(name) && p.IdEstado == 1
                           select p).ToList<Productos>();

            return await Task.FromResult(query);
        }

        public async Task<List<Productos>> getbyPriceList()
        {
            var query = (from pl in this.DBcontex.ProductosListaPrecios
                         join p in this.DBcontex.Productos on pl.IdProducto equals p.Id
                         where p.IdEstado == 1
                         select p).ToList<Productos>();

            return await Task.FromResult(query);
        }
    

        public async Task<Productos> update(Productos model)
        {
            var result = this.DBcontex.Productos.SingleOrDefault(b => b.Id == model.Id && b.IdEstado==1);

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

        public async Task<List<ProductosListaPrecios>> getProductListPrice() {

            var query = (from p in this.DBcontex.ProductosListaPrecios
                         where p.IdEstado == 1
                         select p).ToList<ProductosListaPrecios>();

            return await Task.FromResult(query);

        }
    }
}
