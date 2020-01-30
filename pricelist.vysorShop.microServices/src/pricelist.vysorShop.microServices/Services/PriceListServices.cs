using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pricelist.vysorShop.microServices.Models;
using pricelist.vysorShop.microServices.Models.Interfaces;
using pricelist.vysorShop.microServices.Services.Interfaces;

namespace pricelist.vysorShop.microServices.Services
{
    public class PriceListServices:IPriceListServices
    {


        private IPriceListRepository PriceListRepository;

        public PriceListServices(IPriceListRepository listaPrecios)
        {
            PriceListRepository = listaPrecios;
        }
        public PriceListServices()
        {
        }

        public async Task<ListaPrecios> Add(ListaPrecios model)
        {
            return await this.PriceListRepository.Add(model);
        }

        public async Task<bool> delete(int id)
        {
            return await this.PriceListRepository.delete(id);
        }

        public async Task<List<ListaPrecios>> getAll()
        {
            return await this.PriceListRepository.getAll();
        }

        public async Task<ListaPrecios> getbyId(int id)
        {
            return await this.PriceListRepository.getbyId(id);
        }

        public async Task<ListaPrecios> update(ListaPrecios model)
        {
            return await this.PriceListRepository.update(model);
        }
    }
}
