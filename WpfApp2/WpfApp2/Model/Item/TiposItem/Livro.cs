using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp2
{
    public class Livro : IItemLocavel
    {
        private int codigo;
        private string nome;
        private string autor;
        private int pags;
        public int Codigo { get => codigo; set { codigo = value; } }
        public string Nome
        {
            get => nome;

            set
            {
                if (Valids.CheckStringNullOrEmpty(value))
                {
                    Valids.DisplayValidationError(ValidsStrings.ErroNomeEmptyOrNull);
                }
                else
                {
                    nome = value;
                }
            }
        }
        public string Autor
        {
            get => autor;
            set
            {
                if (Valids.CheckStringNullOrEmpty(value))
                {
                    Valids.DisplayValidationError(ValidsStrings.ErroAutorEmptyOrNull);
                }
                else
                {
                    autor = value;
                }
            }
        }

        public int Pags { get => pags; set {
                if (Valids.CheckIsPositive(value))
                {
                    pags = value;
                } else
                {
                    Valids.DisplayValidationError(ValidsStrings.ErroPagsNegativo);
                }
            } }

        public bool Check(PseudoExc ex)
        {
            if (!Valids.CheckStringNullOrEmpty(nome))
            {
                if (!Valids.CheckStringNullOrEmpty(autor))
                {
                    if (Valids.CheckIsPositive(pags))
                    {
                        return true;
                    }
                    else
                    {
                        ex.ex = ValidsStrings.ErroPagsNegativo;
                    }
                }
                else
                {
                    ex.ex = ValidsStrings.ErroAutorEmptyOrNull;
                }
            }
            else
            {
                ex.ex = ValidsStrings.ErroNomeEmptyOrNull;
            }
            return false;
        }

        public TipoItem GetTipoItem()
        {
            return TipoItem.Livro;
        }
        public IItem Clone()
        {
            return (Livro)MemberwiseClone();
        }
    }
}
