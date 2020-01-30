using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using cellar.vysorShop.microServices.Models;
using cellar.vysorShop.microServices.Models.Interface;
using cellar.vysorShop.microServices.Services.Interfaces;

namespace cellar.vysorShop.microServices.Services
{
    public class CellarServices : ICellarServices
    {
        private ICellarRepository CellarRepository;

        public CellarServices(ICellarRepository cellar)
        {
            CellarRepository = cellar;
        }

        public CellarServices()
        {
           
        }


        public async Task<bool> delete(int id)
        {
            return await this.CellarRepository.delete(id);
        }

        public async Task<List<Bodegas>> getAll()
        {
            return await this.CellarRepository.getAll();
        }

        public async Task<Bodegas> getbyId(int id)
        {
            return await this.CellarRepository.getbyId(id);
        }

        public async Task<Bodegas> update(Bodegas model)
        {
            return await this.CellarRepository.update(model);
        }

        public async Task<List<Bodegas>> getbyName(string name)
        {
            return await this.CellarRepository.getbyName(name);
        }

        public async Task<List<Bodegas>> getbyDoc(string doc)
        {
            return await this.CellarRepository.getbyDoc(doc);
        }


        public async Task<Bodegas> Add(Bodegas model)
        {
            return await this.CellarRepository.AddAsync(model);
        }
    }
}
