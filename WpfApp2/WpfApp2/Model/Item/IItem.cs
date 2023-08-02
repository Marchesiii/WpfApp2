using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public interface IItem
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public TipoItem GetTipoItem();
        public bool Check(PseudoExc ex);
        public IItem Clone();

    }
}
