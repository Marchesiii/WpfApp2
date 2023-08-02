using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    public class BuildTipoItem
    {
        public static IItem? GetItemByTipo(TipoItem tipoItem)
        {
            IItem item = null;
            switch (tipoItem)
            {
                case TipoItem.Pessoa:
                    item = new Pessoa();
                    break;
                case TipoItem.Livro:
                    item = new Livro();
                    break;
                default:
                    break;
            }
            return item;
        }


        public static Window? GetTelaCadastro(TipoItem tipo)
        {
            Window window = null;
            switch (tipo)
            {
                case TipoItem.Pessoa:
                    window = new TelaCadastroPessoa();
                    break;
                case TipoItem.Livro:
                    window = new TelaCadastroLivro();
                    break;
                default:
                    break;
            }
            return window;
        }

        public static Window? GetTelaInfo(TipoItem tipo)
        {
            Window window = null;
            switch (tipo)
            {
                case TipoItem.Pessoa:
                    window = new TelaInfoPessoa();
                    break;
                case TipoItem.Livro:
                    window = new TelaInfoLivro();
                    break;
                default:
                    break;
            }
            return window;
        }

        public static TelaInfoVm BuildTelaInfo(TelaInfoVm tela, IItem item, ILocador empresa)
        {
            tela.Codigo = item.Codigo;
            tela.Nome = item.Nome;
            if (item.GetTipoItem().Equals(TipoItem.Pessoa))
            {
                Pessoa pessoa = (Pessoa)item;
                IEnumerable<Emprestimo> lista = empresa.GetVinculoPerLocador(pessoa.Codigo);
                if (lista.Any())
                {
                    List<IItemLocavel> livros = new List<IItemLocavel>();
                    foreach (Emprestimo emp in lista)
                    {
                        livros.Add((IItemLocavel)empresa.Get(emp.CodigoLocavel, TipoItem.Livro));
                    }
                    tela.LivrosEmprestados = livros;
                }
            }
            else
            {
                Livro livro = (Livro)item;
                IEnumerable<Emprestimo> lista = empresa.GetVinculoPerLocado(livro.Codigo);
                tela.Autor = livro.Autor;
                tela.Pags = livro.Pags;
                if (lista.Any())
                {
                    tela.Pessoa = (IItemLocador)empresa.Get(lista.First().CodigoLocador, TipoItem.Pessoa);
                }
            }
            return tela;
        }
    }
    
}
