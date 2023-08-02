using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    public class TelaEmprestimoVm
    {
        public ObservableCollection<IItem> ListaListavel { get; set; }
        public IItem? ItemSelecionado { get; set; }
        public ILocador Locadora { get; set; }
        public IItemLocavel Item { get; set; }
        public bool Tentou { get; set; }

        public TelaEmprestimoVm()
        {
            Tentou = false;
        }

        public bool EmprestarItem()
        {
            Tentou = true;
            if (ItemSelecionado != null)
            {
                Locadora.Vincula(Item.Codigo, Item.GetTipoItem(), ItemSelecionado.Codigo, ItemSelecionado.GetTipoItem());
                MessageBox.Show(nameof(Item) + " emprestado para: " + ItemSelecionado.Nome);
                return true;
            }
            else
            {
                MessageBox.Show("Selecione ao menos um locatário para efetivar o emprestimo ou feche a aba.");
                return false;
            }
        }
    }
}

