using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace guiP1B.Clases
{
    public class CrudTarea
    {
        string connectionString = "Server=LAPTOP-0VH2N7ML\\SQLEXPRESS01;Database=UMG;Integrated Security=True; TrustServerCertificate=True; ";

        public string AgregarTarea(string carnet, string nombreTarea, string descripcion, string seccion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO tareas (carnet_alumno, tarea_nombre) VALUES (@carnet_alumno, @tarea_nombre)";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet_alumno", carnet);
                    command.Parameters.AddWithValue("@tarea_nombre", descripcion);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return "Tarea agregada exitosamente.";
                }
                catch (Exception ex)
                {
                    return "Error al agregar la tarea: " + ex.Message;
                }
            }
        }

        public string MostrarTarea(string carnet_alumno)
        {
            string tarea_nombre = "No se encontró la tarea.";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre_tarea FROM tareas WHERE carnet_alumno = @carnet_alumno";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet_alumno", carnet_alumno);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tarea_nombre = reader["tarea_nombre"].ToString();
                    }
                }
                catch (Exception)
                {
                tarea_nombre = "Error al buscar tarea.";
                }
            }
            return tarea_nombre;
        }
        public string EliminarTarea(string carnet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM tareas WHERE carnet_alumno = @carnet";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return "Tarea eliminada exitosamente.";
                    }
                    else
                    {
                        return "No se encontró ninguna tarea con ese carnet.";
                    }
                }
                catch (Exception ex)
                {
                    return "Error al eliminar la tarea: " + ex.Message;
                }
            }
        }


    }
}






