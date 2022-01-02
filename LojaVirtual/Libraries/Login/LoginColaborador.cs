using LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {
        private string key = "Login.Colaborador";

        private Sessao.Sessao _sessao;

        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            string colaboradorJSON = JsonConvert.SerializeObject(colaborador);

            _sessao.Cadastrar(key, colaboradorJSON);
        }

        public Colaborador GetColaborador()
        {
            if (_sessao.Existe(key))
            {
                string colaboradorJSON = _sessao.Consultar(key);
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJSON);
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
