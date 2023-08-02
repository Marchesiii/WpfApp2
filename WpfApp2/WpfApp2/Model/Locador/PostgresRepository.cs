using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db;

namespace WpfApp2.Model.Locador
{
    class PostgresRepository : ILocador
    {
        private PostgresConnection con;
        public PostgresRepository(PostgresConnection conn)
        {
            con = conn;
        }
        public bool Adiciona(IItem item)
        {
            bool result = false;
            string query;
            if (item.GetTipoItem().Equals(TipoItem.Pessoa))
            {
                query = @"INSERT INTO public.pessoa(nome) VALUES (@nome);";
                try
                {
                    result = con.GetConnection().Execute(sql: query, param: (Pessoa)item) > 0;
                }
                catch (Exception e)
                {
                    Valids.DisplayValidationError(e.Message);
                }
            }
            else
            {
                query = @"INSERT INTO public.livro(nome, autor, pags) VALUES (@nome, @autor, @pags);";
                try
                {
                    result = con.GetConnection().Execute(sql: query, param: (Livro)item) > 0;
                }
                catch (Exception e)
                {
                    Valids.DisplayValidationError(e.Message);
                }
            }


            return result;
        }

        public bool Desvincula(int codigolocavel)
        {
            bool result = false;
            string query = @"DELETE FROM public.emprestimo WHERE codigolocavel = @codigolocavel;";
            try
            {
                Emprestimo emp = GetVinculoPerLocado(codigolocavel).First();
                result = con.GetConnection().Execute(sql: query, param: emp) > 0;
            }
            catch (Exception e)
            {
                Valids.DisplayValidationError(e.Message);
            }
            return result;
        }

        public IItem Get(int codigo, TipoItem tipo)
        {
            string query;
            IItem result = null;
            if (tipo.Equals(TipoItem.Pessoa))
            {
                query = @"SELECT * FROM public.pessoa WHERE codigo = @codigo;";
                try
                {

                    Pessoa pessoa = new Pessoa();
                    pessoa.Codigo = codigo;
                    result = con.GetConnection().Query<Pessoa>(sql: query, param: pessoa).ToList().First();

                }
                catch (Exception e)
                {
                    Valids.DisplayValidationError(e.Message);
                }
            }
            else
            {
                query = @"SELECT * FROM public.livro WHERE codigo = @codigo;";
                try
                {
                    Livro livro = new Livro();
                    livro.Codigo = codigo;
                    result = con.GetConnection().Query<Livro>(sql: query, param: livro).ToList().First();
                }
                catch (Exception e)
                {
                    Valids.DisplayValidationError(e.Message);
                }
            }
            return result;
        }

        public List<IItem> GetItems(TipoItem tipo)
        {
            string query;
            List<IItem> result;
            if (tipo.Equals(TipoItem.Pessoa))
            {
                query = @"SELECT * FROM pessoa;";
                result = con.GetConnection().Query<Pessoa>(sql: query).ToList<IItem>();
            }
            else
            {
                query = @"SELECT * FROM livro;";
                result = con.GetConnection().Query<Livro>(sql: query).ToList<IItem>();
            }
            return result;
        }

        public Emprestimo? GetVinculo(int codigo)
        {
            string query;
            query = @"SELECT * FROM emprestimo WHERE codigo = @codigo;";
            try
            {
                Emprestimo emp = new Emprestimo();
                emp.Codigo = codigo;
                return con.GetConnection().Query<Emprestimo>(sql: query, param: emp).FirstOrDefault();
            }
            catch (Exception e)
            {
                Valids.DisplayValidationError(e.Message);
            }
            return null;
        }

        public List<Emprestimo> GetVinculoPerLocado(int codigolocavel)
        {
            string query;
            query = @"SELECT * FROM emprestimo WHERE codigolocavel = @codigolocavel;";
            try
            {
                Emprestimo emp = new Emprestimo();
                emp.CodigoLocavel = codigolocavel;
                return con.GetConnection().Query<Emprestimo>(sql: query, param: emp).ToList();
            }
            catch (Exception e)
            {
                Valids.DisplayValidationError(e.Message);
            }
            return null;
        }

        public List<Emprestimo> GetVinculoPerLocador(int codigolocador)
        {
            string query;
            query = @"SELECT * FROM emprestimo WHERE codigolocador = @codigolocador;";
            try
            {
                Emprestimo emp = new Emprestimo();
                emp.CodigoLocador = codigolocador;
                return con.GetConnection().Query<Emprestimo>(sql: query, param: emp).ToList();
            }
            catch (Exception e)
            {
                Valids.DisplayValidationError(e.Message);
            }
            return null;
        }

        public bool Remove(IItem item)
        {
            bool result = false;
            string query;
            if (item.GetTipoItem().Equals(TipoItem.Pessoa))
            {
                query = @"DELETE FROM public.pessoa WHERE codigo = @codigo;";
                try
                {
                    result = con.GetConnection().Execute(sql: query, param: (Pessoa)item) > 0;
                }
                catch (Exception e)
                {
                    Valids.DisplayValidationError(e.Message);
                }
            }
            else
            {
                query = @"DELETE FROM public.livro WHERE codigo = @codigo;";
                try
                {
                    result = con.GetConnection().Execute(sql: query, param: (Livro)item) > 0;
                }
                catch (Exception e)
                {
                    Valids.DisplayValidationError(e.Message);
                }
            }


            return result;
        }

        public bool Update(IItem item, IItem itemClone)
        {
            bool result = false;
            string query;
            if (item.GetTipoItem().Equals(TipoItem.Pessoa))
            {
                query = @"UPDATE public.pessoa set nome = @nome WHERE codigo = @codigo;";
                try
                {
                    result = con.GetConnection().Execute(sql: query, param: (Pessoa)itemClone) > 0;
                }
                catch (Exception e)
                {
                    Valids.DisplayValidationError(e.Message);
                }
            }
            else
            {
                query = @"UPDATE public.livro set nome = @nome, autor = @autor, pags = @pags WHERE codigo = @codigo;";
                try
                {
                    result = con.GetConnection().Execute(sql: query, param: (Livro)itemClone) > 0;
                }
                catch (Exception e)
                {
                    Valids.DisplayValidationError(e.Message);
                }
            }


            return result;
        }

        public bool Vincula(int codigolocavel, TipoItem tipo1, int codigolocador, TipoItem tipo2)
        {
            bool result = false;
            string query = @"INSERT INTO public.emprestimo(codigolocavel, codigolocador) VALUES (@codigolocavel, @codigolocador);";
            try
            {
                Emprestimo emp = new Emprestimo();
                emp.CodigoLocavel = codigolocavel;
                emp.CodigoLocador = codigolocador;
                result = con.GetConnection().Execute(sql: query, param: emp) > 0;
            }
            catch (Exception e)
            {
                Valids.DisplayValidationError(e.Message);
            }
            return result;

        }
    }
}
