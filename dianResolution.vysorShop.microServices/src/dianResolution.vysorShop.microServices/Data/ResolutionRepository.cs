using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dianResolution.vysorShop.microServices.Models;
using dianResolution.vysorShop.microServices.Models.Interfaces;
namespace dianResolution.vysorShop.microServices.Data
{
    public class ResolutionRepository:IResolutionRepository
    {
        private Context DBcontex;

        public ResolutionRepository(Context Context)
        {
            this.DBcontex = Context;
        }

        public async Task<ResolucionDian> Add(ResolucionDian model)
        {
            this.DBcontex.ResolucionDian.Add(model);
            this.DBcontex.SaveChanges();
            return await Task.FromResult(model);

        }

      
        public async Task<List<ResolucionDian>> getAll()
        {
            var query = (from p in this.DBcontex.ResolucionDian
                         select p).ToList<ResolucionDian>();

            return await Task.FromResult(query);
        }

        public async Task<ResolucionDian> getbyId(int id)
        {
            var query = (from p in this.DBcontex.ResolucionDian
                         where p.Pos == id 
                         select p).FirstOrDefault<ResolucionDian>();

            return await Task.FromResult(query);
        }     

        public async Task<ResolucionDian> update(ResolucionDian model)
        {
            var result = this.DBcontex.ResolucionDian.SingleOrDefault(b => b.IdresolucionDian == model.IdresolucionDian);

            if (result != null)
            {
                this.DBcontex.Entry(result).CurrentValues.SetValues(model);
                this.DBcontex.SaveChanges();
                return await Task.FromResult(model);
            }
            else
            {
                return await Task.FromResult(result);
            }

        }
        
    }
}
