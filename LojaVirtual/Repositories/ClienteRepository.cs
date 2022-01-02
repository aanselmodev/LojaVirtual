using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private LojaVirtualContext _banco;

        public ClienteRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Cliente cliente)
        {
            _banco.Clientes.Update(cliente);
            _banco.SaveChanges();
        }

        public void Cadastrar(Cliente cliente)
        {
            _banco.Clientes.Add(cliente);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Cliente cliente = ObterCliente(id);
            _banco.Clientes.Remove(cliente);
            _banco.SaveChanges();
        }

        public Cliente Login(string email, string senha)
        {
            return _banco.Clientes.Where(m => m.Email == email && m.Senha == senha).FirstOrDefault();
        }

        public Cliente ObterCliente(int id)
        {
            return _banco.Clientes.Find(id);
        }

        public IEnumerable<Cliente> ObterClientes()
        {
            return _banco.Clientes.ToList();
        }
    }
}
