using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dianResolution.vysorShop.microServices.Models.Interfaces
{
    public interface IResolutionRepository
    {
        Task<ResolucionDian> Add(ResolucionDian model);
        Task<List<ResolucionDian>> getAll();
        Task<ResolucionDian> getbyId(int id);
        Task<ResolucionDian> update(ResolucionDian model);
    }
}
