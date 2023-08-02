using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Db;
using WpfApp2.Model.Locador;

namespace WpfApp2
{
    public class MainWindowVm : INotifyPropertyChanged
    {

        private readonly ILocador locadora;
        private readonly IDbConnection conn;
        public MainWindowVm()
        {
            locadora = new PostgresRepository(new PostgresConnection());
            IniciaCommandos();
        }

        public ICommand Add { get; private set; }
        public ICommand Remove { get; private set; }
        public ICommand Update { get; private set; }
        public ICommand Emprestar { get; set; }
        public ICommand Devolver { get; set; }
        public ICommand Info { get; set; }
        public ObservableCollection<IItem> ListaListable { get; private set; }

        public TipoItem TipoSelecionado { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public IItem ItemSelecionado { get; set; }

        private void IniciaCommandos()
        {
            ListaListable = new ObservableCollection<IItem>();
            TipoSelecionado = TipoItem.Pessoa;
            if (locadora == null)
            {
                Valids.DisplayValidationError(ValidsStrings.ErroLocadoraNull);
                return;
            }
            GetVmListableWithNotify();

            Add = new RelayCommand((param) =>
            {
                IItem? novoItem = BuildTipoItem.GetItemByTipo(TipoSelecionado);
                if (novoItem != null)
                {
                    if (AlterarItem(novoItem))
                    {
                        if (!locadora.Adiciona(novoItem))
                        {
                            Valids.DisplayValidationError(ValidsStrings.ErroAdicionarItem);
                        }
                    }
                }
                GetVmListableWithNotify();
            });

            Remove = new RelayCommand((param) =>
            {
                if (ItemSelecionado != null)
                {
                    if (!locadora.Remove(ItemSelecionado))
                    {
                        Valids.DisplayValidationError(ValidsStrings.ErroRemoverItem);
                    }
                }
                GetVmListableWithNotify();
            }, (param2) => VerifyItemSelecionadoDesocupado()
            );

            Update = new RelayCommand((param) =>
            {
                if (ItemSelecionado != null)
                {
                    IItem item = ItemSelecionado;
                    IItem itemClone = ItemSelecionado.Clone();
                    bool alterou = AlterarItem(itemClone);
                    bool result = false;
                    if (alterou)
                    {
                        result = locadora.Update(item, itemClone);

                    }

                    if (!result)
                    {
                        Valids.DisplayValidationError(ValidsStrings.ErroAtualizaItem);
                    }

                }
                GetVmListableWithNotify();
            }, (param2) => ItemSelecionado != null
            );

            Emprestar = new RelayCommand((param) =>
            {
                if (ItemSelecionado != null)
                {
                    IItemLocavel livro = (IItemLocavel)ItemSelecionado;
                    try
                    {
                        bool results = false;
                        TelaEmprestimoVm tela = null;
                        while (!results && (tela == null || tela.Tentou == true))
                        {
                            tela = new TelaEmprestimoVm();
                            TelaEmprestimo listaEmp = new TelaEmprestimo();
                            tela.ListaListavel = new ObservableCollection<IItem>(locadora.GetItems(TipoItem.Pessoa));
                            tela.Locadora = locadora;
                            tela.Item = (IItemLocavel)ItemSelecionado.Clone();
                            listaEmp.Tela = tela;
                            listaEmp.DataContext = tela;
                            listaEmp.ShowDialog();
                            results = (bool)listaEmp.DialogResult;
                        }
                    }
                    finally
                    {
                        GetVmListableWithNotify();
                    }
                }
            }, (param2) =>
            {
                if (ItemSelecionado != null && ItemSelecionado.GetType().GetInterfaces().Where(nome => nome.Name.Equals(nameof(IItemLocavel))).Any())
                {

                    return VerifyItemSelecionadoDesocupado();
                }
                return false;
            });

            Devolver = new RelayCommand((param) =>
            {
                if (ItemSelecionado != null)
                {
                    IItem item = ItemSelecionado;
                    locadora.Desvincula(item.Codigo);
                    MessageBox.Show("Item devolvido");
                }
                Notifica(nameof(ListaListable));
            }, (param2) =>
            {
                if (ItemSelecionado != null && ItemSelecionado.GetType().GetInterfaces().Where(nome => nome.Name.Equals(nameof(IItemLocavel))).Any())
                {
                    return !VerifyItemSelecionadoDesocupado();
                }
                return false;
            });

            Info = new RelayCommand((param) =>
            {
                if (ItemSelecionado != null)
                {
                    Window? tela = BuildTipoItem.GetTelaInfo(ItemSelecionado.GetTipoItem());
                    if (tela != null)
                    {
                        TelaInfoVm telaInfo = new TelaInfoVm();
                        BuildTipoItem.BuildTelaInfo(telaInfo, ItemSelecionado, locadora);
                        tela.DataContext = telaInfo;
                        tela.ShowDialog();
                    }
                }
            }, (param2) => ItemSelecionado != null
           );

        }

        public void Notifica(string nome)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
        }

        public void GetVmListableWithNotify()
        {
            if (locadora != null)
            {
                ListaListable = new ObservableCollection<IItem>(locadora.GetItems(TipoSelecionado));
                Notifica(nameof(ListaListable));
            }
        }
        private bool VerifyItemSelecionadoDesocupado()
        {
            if (ItemSelecionado != null)
            {

                if (ItemSelecionado.GetTipoItem().Equals(TipoItem.Pessoa))
                {
                    if (!locadora.GetVinculoPerLocador(ItemSelecionado.Codigo).Any())
                    {
                        return true;
                    }
                }
                else
                {
                    if (!locadora.GetVinculoPerLocado(ItemSelecionado.Codigo).Any())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool AlterarItem(IItem itemClone)
        {
            bool dialogResult = true;
            while (dialogResult)
            {
                Window? tela = BuildTipoItem.GetTelaCadastro(itemClone.GetTipoItem());
                if (tela == null)
                {
                    return false;
                }
                tela.DataContext = itemClone;
                tela.ShowDialog();
                dialogResult = (bool)tela.DialogResult;
                if (dialogResult)
                {
                    PseudoExc ex = new PseudoExc();
                    if (itemClone.Check(ex))
                    {
                        return true;
                    }
                    else
                    {
                        Valids.DisplayValidationError(ex.ex);
                    }
                }
            }
            return false;
        }
    }
}