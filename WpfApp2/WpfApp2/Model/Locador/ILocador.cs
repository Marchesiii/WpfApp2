using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public interface ILocador
    {
        bool Adiciona(IItem item);
        bool Remove(IItem item);
        bool Update(IItem item, IItem itemClone);
        IItem Get(int codigo, TipoItem tipo);
        List<IItem> GetItems(TipoItem tipo);
        bool Vincula(int codigoLocavel, TipoItem tipo1, int codigoLocador, TipoItem tipo2);
        bool Desvincula(int codigoLocavel);
        Emprestimo? GetVinculo(int codigo);
        List<Emprestimo> GetVinculoPerLocado(int codigoLocado);
        List<Emprestimo> GetVinculoPerLocador(int codigoLocador);
    }
}
