using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private string key = "Login.Cliente";

        private Sessao.Sessao _sessao;

        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            string clienteJSON = JsonConvert.SerializeObject(cliente);

            _sessao.Cadastrar(key, clienteJSON);
        }

        public Cliente GetCliente()
        {
            if (_sessao.Existe(key))
            {
                string clienteJSON = _sessao.Consultar(key);
                return JsonConvert.DeserializeObject<Cliente>(clienteJSON);
            }
            else
            {
                return null;
            }
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
