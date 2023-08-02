using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    public class Pessoa : IItemLocador
    {
        private int codigo;
        private string nome;
        public int Codigo
        {
            get => codigo;
            set
            {
                codigo = value;
            }
        }
        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                   Valids.DisplayValidationError(ValidsStrings.ErroNomeEmptyOrNull);
                }
                else
                {
                    nome = value;
                }
            }
        }
        public bool Check(PseudoExc ex)
        {
            if (string.IsNullOrEmpty(nome))
            {
                ex.ex = ValidsStrings.ErroNomeEmptyOrNull;
                return false;
            }
            else
            {
                return true;
            }
        }

        public TipoItem GetTipoItem()
        {
            return TipoItem.Pessoa;
        }
        public IItem Clone()
        {
            Pessoa clone = (Pessoa)MemberwiseClone();
            return clone;
        }
    }
}
