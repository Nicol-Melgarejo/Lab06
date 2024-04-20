using System;
using System.Data.SqlClient;
using System.Windows;

namespace Lab06
{
    public partial class Insertar : Window
    {
        private string connectionString;

        public Insertar()
        {
            InitializeComponent();
            connectionString = "Data Source=LAB1504-23\\SQLEXPRESS;Initial Catalog=Neptunobd; User Id=User01;Password=123456";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string idEmpleado = txtIdEmpleado.Text;
            string apellidos = txtApellidos.Text;
            string nombre = txtNombre.Text;
            string cargo = txtCargo.Text;
            string tratamiento = txtTratamiento.Text;
            DateTime fechaNacimiento = dpFechaNacimiento.SelectedDate ?? DateTime.MinValue;
            DateTime fechaContratacion = dpFechaContratacion.SelectedDate ?? DateTime.MinValue;
            string direccion = txtDireccion.Text;
            string ciudad = txtCiudad.Text;
            string region = txtRegion.Text;
            string codPostal = txtCodPostal.Text;
            string pais = txtPais.Text;
            string telDomicilio = txtTelDomicilio.Text;
            string extension = txtExtension.Text;
            string notas = txtNotas.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("USP_InsertarEmpleados", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                        command.Parameters.AddWithValue("@Apellidos", apellidos);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Cargo", cargo);
                        command.Parameters.AddWithValue("@Tratamiento", tratamiento);
                        command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                        command.Parameters.AddWithValue("@FechaContratacion", fechaContratacion);
                        command.Parameters.AddWithValue("@Direccion", direccion);
                        command.Parameters.AddWithValue("@Ciudad", ciudad);
                        command.Parameters.AddWithValue("@Region", region);
                        command.Parameters.AddWithValue("@CodPostal", codPostal);
                        command.Parameters.AddWithValue("@Pais", pais);
                        command.Parameters.AddWithValue("@TelDomicilio", telDomicilio);
                        command.Parameters.AddWithValue("@Extension", extension);
                        command.Parameters.AddWithValue("@Notas", notas);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Empleado insertado correctamente.");
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("La inserción del empleado ha fallado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el empleado: " + ex.Message);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Window ventanaActual = Window.GetWindow(this);
            ventanaActual.Close();
        }

        private void LimpiarCampos()
        {
            txtIdEmpleado.Text = "";
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtCargo.Text = "";
            txtTratamiento.Text = "";
            dpFechaNacimiento.SelectedDate = null;
            dpFechaContratacion.SelectedDate = null;
            txtDireccion.Text = "";
            txtCiudad.Text = "";
            txtRegion.Text = "";
            txtCodPostal.Text = "";
            txtPais.Text = "";
            txtTelDomicilio.Text = "";
            txtExtension.Text = "";
            txtNotas.Text = "";
        }
    }
}
