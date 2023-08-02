using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class ValidsStrings
    {
        public const string ErroPagsNegativo = "O numero de paginas precsa ser positivo.";

        public const string ErroAutorEmptyOrNull = "O Autor precisa ser preenchido.";

        public const string ErroNomeEmptyOrNull = "O Nome precisa ser preenchido.";
        public const string ErroAdicionarItem = "Não foi possivel adicionar o item.";
        public const string ErroRemoverItem = "Não foi possível remover o item.";

        public const string ErroAtualizaItem = "Não foi possível atualizar o item.";
        public const string ErroPagsNonNumber = "O campo de páginas aceita apenas números.";
        public const string ErroLocadoraNull = "Não foi definida uma empresa locadora.";
    }
}
