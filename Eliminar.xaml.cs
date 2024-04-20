using System;
using System.Data.SqlClient;
using System.Windows;

namespace Lab06
{
    public partial class Eliminar : Window
    {
        private string connectionString;

        public Eliminar()
        {
            InitializeComponent();
            connectionString = "Data Source=LAB1504-23\\SQLEXPRESS;Initial Catalog=Neptunobd; User Id=User01;Password=123456";
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            string idEmpleado = txtIdEmpleado.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("USP_EliminarEmpleados", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Empleado eliminado correctamente.");
                            txtIdEmpleado.Text = ""; 
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún empleado con el ID especificado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el empleado: " + ex.Message);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Window ventanaActual = Window.GetWindow(this);
            ventanaActual.Close();
        }
    }
}
