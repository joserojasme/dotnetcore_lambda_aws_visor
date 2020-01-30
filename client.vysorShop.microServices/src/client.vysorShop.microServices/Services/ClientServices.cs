using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using client.vysorShop.microServices.Models;
using client.vysorShop.microServices.Models.Interfaces;
using client.vysorShop.microServices.Services.Interfaces;

namespace client.vysorShop.microServices.Services
{
    public class ClientServices:IClientServices
    {
        private IClientRepository ClientRepository;

        public ClientServices(IClientRepository client)
        {
            ClientRepository = client;
        }
        public ClientServices()
        {
        }

        public async Task<Clientes> Add(Clientes model)
        {
            return await this.ClientRepository.Add(model);
        }

        public async Task<bool> delete(int id)
        {
            return await this.ClientRepository.delete(id);
        }

        public async Task<List<Clientes>> getAll()
        {
            return await this.ClientRepository.getAll();
        }

        public async Task<Clientes> getbyId(int id)
        {
            return await this.ClientRepository.getbyId(id);
        }

        public async Task<Clientes> update(Clientes model)
        {
            return await this.ClientRepository.update(model);
        }

        public async Task<List<Clientes>> getbyName(string name)
        {
            return await this.ClientRepository.getbyName(name);
        }

        public async Task<List<Clientes>> getbyDoc(string doc)
        {
            return await this.ClientRepository.getbyDoc(doc);
        }
    }
}