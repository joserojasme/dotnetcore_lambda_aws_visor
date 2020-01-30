using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dianResolution.vysorShop.microServices.Models;

namespace dianResolution.vysorShop.microServices.Services.Interfaces
{
    public interface IResolutionServices
    {
        Task<ResolucionDian> Add(ResolucionDian model);
        Task<List<ResolucionDian>> getAll();
        Task<ResolucionDian> getbyId(int id);
        Task<ResolucionDian> update(ResolucionDian model);

    }
}
