using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeradorPalavras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBox.AcceptsReturn = true;
            textBox.AcceptsTab = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            Definicao definicao = null;
            try {
                definicao = JsonConvert.DeserializeObject<Definicao>(textBox.Text);
            
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro na conversão das regras");
                return;
            }

            var ge = new Gerador();
            
            listBox.ItemsSource = ge.Palavras;

            ge.Executar(definicao, int.Parse(txtLimite.Text));
        }
        
    }
}
