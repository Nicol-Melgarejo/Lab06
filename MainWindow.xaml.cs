using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Insertar Empleados = new Insertar();
            Empleados.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Listar Empleados = new Listar();
            Empleados.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Actualizar Empleados = new Actualizar();
            Empleados.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Eliminar Empleados = new Eliminar();
            Empleados.ShowDialog();
        }
    }
}