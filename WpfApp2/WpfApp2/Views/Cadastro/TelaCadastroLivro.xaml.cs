using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    /// <summary>
    /// Lógica interna para TelaCadastroLivro.xaml
    /// </summary>
    public partial class TelaCadastroLivro : Window
    {
        public TelaCadastroLivro()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int pags;
            if (!int.TryParse(TextBox1.Text, out pags))
            {
                Valids.DisplayValidationError(ValidsStrings.ErroPagsNonNumber);
                TextBox1.Text = "0";
                return;
            }
            DialogResult = true;
        }
    }
}
