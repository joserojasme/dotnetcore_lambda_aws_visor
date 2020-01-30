using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dianResolution.vysorShop.microServices.Models;
using dianResolution.vysorShop.microServices.Models.Interfaces;
using dianResolution.vysorShop.microServices.Services.Interfaces;

namespace dianResolution.vysorShop.microServices.Services
{
    public class ResolutionServices:IResolutionServices
    {
        private IResolutionRepository ResolutionRepository;

        public ResolutionServices(IResolutionRepository Resolution)
        {
            ResolutionRepository = Resolution;
        }
        public ResolutionServices()
        {
        }

        public async Task<ResolucionDian> Add(ResolucionDian model)
        {
            return await this.ResolutionRepository.Add(model);
        }


        public async Task<List<ResolucionDian>> getAll()
        {
            return await this.ResolutionRepository.getAll();
        }

        public async Task<ResolucionDian> getbyId(int id)
        {
            return await this.ResolutionRepository.getbyId(id);
        }

      

        public async Task<ResolucionDian> update(ResolucionDian model)
        {
            return await this.ResolutionRepository.update(model);
        }

      
    }
}
