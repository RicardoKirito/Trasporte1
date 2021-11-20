using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Trasporte
{
    public partial class Form1 : Form
    {
        public SqlConnection conxion = new SqlConnection("server = DESKTOP-RTHQME0\\MSSQLSERVER01; database = Transporte; integrated security = true;");


        public Form1()
        {
            InitializeComponent();
            Fechab.Format = DateTimePickerFormat.Short;
            Apellidob.Text = Fechab.Text;

            

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conxion.Open();
            string id = (IDb.Text!="")?$"ID = {IDb.Text}": "";
            string nombre = (Nombreb.Text != "") ? $"Nombre = '{Nombreb.Text}'" : "";
            string apellido = (Apellidob.Text != "") ? $"Apellido = '{Apellidob.Text}'" : "";
            string fecha = (Fechab.Text != "") ? $"Fecha = '{Fechab}'" : "";
            string cedula = (Cedulab.Text != "") ? $"Cedula = '{Cedulab.Text}'" : "";
            

            string buscar = $"Select * From Chofer where {id} {nombre} {apellido}  {cedula}";

            SqlCommand conmando = new SqlCommand(buscar, conxion);
            SqlDataReader registros = conmando.ExecuteReader();
            int contador = 1;
            int y = 30;
                Panelc.BackColor = Color.AliceBlue;
            Panelc.Controls.Clear();
            while (registros.Read())
            {
                //Se definen los elemetos que agregaremos
                Panel nuevoPanel = new Panel();
                Label imagen = new Label();
                Label nuevo = new Label();

                //Cargamos la imagen deseada
                Image foto = Image.FromStream(File.OpenRead("C:\\Users\\LL\\source\\repos\\AgendaE\\avatardefault_92824.png"));

                //Se le da formato al Label que almacendra los datos
                nuevo.AutoSize = true;
                nuevo.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                nuevo.ForeColor = Color.FromArgb(37, 60, 86);
                nuevo.Location = new Point(40, 5);
                nuevo.Name = "Nombre" + Convert.ToString(contador);
                nuevo.Text = $"{registros["Nombre"]} {registros["Apellido"]}";


                //Se le da formato al Panel que contendrá la imagen de usuario (Solo para hacerlo mas bonito)
                imagen.AutoSize = false;
                imagen.BackColor = Color.White;
                imagen.Location = new Point(0, 2);
                imagen.Size = new Size(35, 35);
                imagen.Name = "Imagen" + Convert.ToString(contador);

                //Agregamos la foto
                imagen.Image = foto;

                //Le damos formato al panel
                nuevoPanel.BackColor = Color.White;
                nuevoPanel.Size = new Size(254, 49);
                nuevoPanel.Location = new Point(39, y);
                nuevoPanel.Name = "tabla" + Convert.ToString(contador);

                //Agregamos las Labels
                nuevoPanel.Controls.Add(nuevo);
                nuevoPanel.Controls.Add(imagen);

                //Si el nombre junto con el apellido no cabe en el panel, entoces solo mostraremos el nombre
                

                //incrementamos todos los contadores
                contador++;
                y += 50;

                



                //Agremagamos el panel creado a nuestro panel principal
                Panelc.Controls.Add(nuevoPanel);


            }
            // Cerramos conexion
            conxion.Close();
            

        }

        private void BuscarA_Click(object sender, EventArgs e)
        {
            conxion.Open();
            string id = (IDb.Text != "") ? $"ID = {IDb.Text}" : "";
            string nombre = (Nombreb.Text != "") ? $"Nombre = '{Nombreb.Text}'" : "";
            string apellido = (Apellidob.Text != "") ? $"Apellido = '{Apellidob.Text}'" : "";
            string fecha = (Fechab.Text != "") ? $"Fecha = '{Fechab}'" : "";
            string cedula = (Cedulab.Text != "") ? $"Cedula = '{Cedulab.Text}'" : "";


            string buscar = $"Select * From Chofer where {id} {nombre} {apellido}  {cedula}";

            SqlCommand conmando = new SqlCommand(buscar, conxion);
            SqlDataReader registros = conmando.ExecuteReader();
            int contador = 1;
            int y = 30;
            Panelc.BackColor = Color.AliceBlue;
            Panelc.Controls.Clear();
            while (registros.Read())
            {
                //Se definen los elemetos que agregaremos
                Panel nuevoPanel = new Panel();
                Label nuevo = new Label();

                
                //Se le da formato al Label que almacendra los datos
                nuevo.AutoSize = true;
                nuevo.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                nuevo.ForeColor = Color.FromArgb(37, 60, 86);
                nuevo.Location = new Point(40, 5);
                nuevo.Name = "Nombre" + Convert.ToString(contador);
                nuevo.Text = $"{registros["Marca"]} {registros["Placa"]}";



                //Le damos formato al panel
                nuevoPanel.BackColor = Color.White;
                nuevoPanel.Size = new Size(254, 49);
                nuevoPanel.Location = new Point(39, y);
                nuevoPanel.Name = "tabla" + Convert.ToString(contador);

                //Agregamos las Labels
                nuevoPanel.Controls.Add(nuevo);

                //Si el nombre junto con el apellido no cabe en el panel, entoces solo mostraremos el nombre


                //incrementamos todos los contadores
                contador++;
                y += 50;





                //Agremagamos el panel creado a nuestro panel principal
               Panela.Controls.Add(nuevoPanel);


            }
            // Cerramos conexion
            conxion.Close();
        }
    }
}