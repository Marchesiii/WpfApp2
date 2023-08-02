namespace WpfApp2.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TesteCriaEmprestimo()
        {
            Emprestimo emprestimo = CriaEmprestimoAdicionaParametros();
            bool result = emprestimo.Codigo == 0 && emprestimo.CodigoLocavel == 0 && emprestimo.CodigoLocador == 0;
            Assert.True(result);
        }

        [Test]
        public void TestCreateLivro()
        {
            Livro livro = CriaLivroAdicionaParametros(null, null, null, null);
            bool result = livro.Codigo == 0 && string.IsNullOrEmpty(livro.Nome) && string.IsNullOrEmpty(livro.Autor) && livro.Pags == 0;
            Assert.True(result);
        }

        [Test]
        public void TestCreatePessoa()
        {
            Pessoa pessoa = CriaPessoaVaziaAdicionaNomeECodigo(null, null);
            bool result = pessoa.Codigo == 0 && string.IsNullOrEmpty(pessoa.Nome);
            Assert.True(result);
        }

        [Test]
        public void TestCheckLivroNome()
        {
            Livro livro = CriaLivroAdicionaParametros(null, null, null, null);
            Assert.True(TesteCheckItemBase(livro, ValidsStrings.ErroNomeEmptyOrNull));

        }

        [Test]
        public void TestCheckLivroAutor()
        {
            Livro livro = CriaLivroAdicionaParametros(null, "a", null, null);
            Assert.True(TesteCheckItemBase(livro, ValidsStrings.ErroAutorEmptyOrNull));
        }

        [Test]
        public void TestCheckLivroPags()
        {
            Livro livro = CriaLivroAdicionaParametros(null, "Nome", "Autor", null);

            Assert.True(livro.Pags == 0);
        }

        [Test]
        public void TesteCheckLivroClone()
        {
            Livro livro = CriaLivroAdicionaParametros(2, "Nome", "Autor", 10);
            Livro livro2 = (Livro)livro.Clone();
            bool result = livro.Codigo.Equals(livro2.Codigo) && livro.Nome.Equals(livro2.Nome) && livro.Autor.Equals(livro2.Autor) && livro.Pags.Equals(livro2.Pags);
            Assert.True(result);
        }

        [Test]
        public void TesteCheckPessoaNome()
        {
            Pessoa pessoa = CriaPessoaVazia();
            Assert.True(TesteCheckItemBase(pessoa, ValidsStrings.ErroNomeEmptyOrNull));
        }

        [Test]
        public void TesteCheckPessoaClone()
        {
            Pessoa pessoa = CriaPessoaVaziaAdicionaNomeECodigo("Teste", 2);
            Pessoa pessoa2 = (Pessoa)pessoa.Clone();
            bool result = pessoa.Codigo.Equals(pessoa2.Codigo) && pessoa.Nome.Equals(pessoa2.Nome);
            Assert.True(result);
        }



        private static Emprestimo CriaEmprestimoAdicionaParametros()
        {
            return new Emprestimo();
        }

        private static Livro CriaLivroVazio()
        {
            return new();
        }

        private static Livro LivroAdicionaCodigo(Livro livro, int? codigo)
        {
            if (codigo != null)
            {
                livro.Codigo = (int)codigo;
            }
            return livro;
        }

        private static Livro LivroAdicionaNome(Livro livro, string? nome)
        {
            if (nome != null)
            {
                livro.Nome = nome;
            }
            return livro;
        }

        private static Livro LivroAdicionaAutor(Livro livro, string? autor)
        {
            if (autor != null)
            {
                livro.Autor = autor;
            }
            return livro;
        }

        private static Livro LivroAdicionaPags(Livro livro, int? pags)
        {
            if (pags != null)
            {
                livro.Pags = (int)pags;
            }
            return livro;
        }

        private static Livro CriaLivroAdicionaParametros(int? codigo, string? nome, string? autor, int? pags)
        {
            Livro livro = CriaLivroVazio();
            LivroAdicionaCodigo(livro, codigo);
            LivroAdicionaNome(livro, nome);
            LivroAdicionaAutor(livro, autor);
            LivroAdicionaPags(livro, pags);
            return livro;

        }

        private static Pessoa CriaPessoaVazia()
        {
            return new();
        }

        private static Pessoa PessoaAdicionaCodigo(Pessoa pessoa, int? codigo)
        {
            if (codigo != null)
            {
                pessoa.Codigo = (int)codigo;
            }
            return pessoa;
        }

        private static Pessoa PessoaAdicionaNome(Pessoa pessoa, string nome)
        {
            if (nome != null)
            {
                pessoa.Nome = nome;
            }
            return pessoa;
        }

        private static Pessoa CriaPessoaVaziaAdicionaNomeECodigo(string? nome, int? codigo)
        {
            Pessoa pessoa = CriaPessoaVazia();
            PessoaAdicionaCodigo(pessoa, codigo);
            PessoaAdicionaNome(pessoa, nome);
            return pessoa;
        }


        public bool TesteCheckItemBase(IItem item, string valid)
        {
            PseudoExc exc = new();
            return !item.Check(exc) && exc.ex.Equals(valid);
        }


    }
}