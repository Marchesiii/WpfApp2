using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Lógica interna para TelaInfoPessoa.xaml
    /// </summary>
    public partial class TelaInfoPessoa : Window
    {
        public TelaInfoPessoa()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
