using LojaVirtual.Database;
using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories.Contracts
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private LojaVirtualContext _banco;
        private const int _registroPorPagina = 10;

        public CategoriaRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }
        
        public void Atualizar(Categoria categoria)
        {

            _banco.Categorias.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _banco.Categorias.Add(categoria);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Categoria categoria = ObterCategoria(id);
            _banco.Categorias.Remove(categoria);
            _banco.SaveChanges();
        }
      
        public Categoria ObterCategoria(int id)
        {
            return _banco.Categorias.Find(id);
        }

        public IPagedList<Categoria> ObterTodasCategorias(int? pagina)
        {
            int numeroPagina = pagina ?? 1;

            return _banco.Categorias.Include(m => m.CategoriaPai).ToPagedList<Categoria>(numeroPagina, _registroPorPagina);
        }
    }
}
