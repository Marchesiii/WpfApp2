using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class TelaInfoVm
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int Pags { get; set; }
        public List<IItemLocavel> LivrosEmprestados { get; set; }
        public IItemLocador Pessoa { get; set; }
        public TelaInfoVm() { }
    }
}
