﻿using CRMobil.Entities;
using CRMobil.Entities.Cliente;
using CRMobil.Entities.Usuarios;
using CRMobil.Interfaces;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CRMobil.Services
{
    public class ClientesService : IClientesServices
    {
        private readonly IMongoCollection<Clientes> _clienteServiceCollection;
        //private readonly IMongoCollection<Usuarios> _usuarioServiceCollection;

        public ClientesService(IOptions<CnnStoreDatabaseSettings> serviceCollection)
        {
            var mongoCollection = new MongoClient(serviceCollection.Value.ConnectionString);

            var mongoDatabase = mongoCollection.GetDatabase(serviceCollection.Value.DatabaseName);

            _clienteServiceCollection = mongoDatabase.GetCollection<Clientes>("Cliente");

            //_usuarioServiceCollection = mongoDatabase.GetCollection<Usuarios>("Usuarios");
        }

        public async Task<List<Clientes>> GetAsync() => await _clienteServiceCollection.Find(_ => true).ToListAsync();

        public async Task<Clientes?> GetAsync(string id) => await _clienteServiceCollection.Find(x => x.Id_Cliente == id).FirstOrDefaultAsync();

        public async Task<Clientes?> GetCpfCnpjAsync(string documento) => await _clienteServiceCollection.Find(x => x.Cnpj_Cpf == documento).FirstOrDefaultAsync();

        //public async Task CreateAsync(Clientes newCliente)
        //{
        //    await _clienteServiceCollection.InsertOneAsync(newCliente);

        //    var usuario = new Usuarios();

        //    usuario.Nome_Usuario = newCliente.Nome_Cliente.Substring(0, newCliente.Nome_Cliente.;
        //    await _usuarioServiceCollection.InsertOneAsync()
        //}  

        public async Task UpdateAsync(string id, Clientes updateCliente) => await _clienteServiceCollection.ReplaceOneAsync(x => x.Id_Cliente == id, updateCliente);

        public async Task RemoveAsync(string id) => await _clienteServiceCollection.DeleteOneAsync(x => x.Id_Cliente == id);

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Clientes createModel)
        {
            throw new NotImplementedException();
        }
    }
}
