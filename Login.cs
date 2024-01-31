using Gestion_de_RT.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_RT
{
    public partial class Login : Form
    {
        private PantallaRegistrarReserva pantalla;
        private List<Usuario> usus;
        private Sesion sesionActual;

        public Login(PantallaRegistrarReserva pantalla, List<Usuario> usus, Sesion sesionActual)
        {
            InitializeComponent();
            this.pantalla = pantalla;
            this.usus = usus;
            this.sesionActual = sesionActual;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool succes = false;
            foreach (Usuario usu in this.usus)
            {
                if (txtUsuario.Text == usu.getNombre() && int.Parse(txtPass.Text) == usu.getPass())
                {
                    this.Hide();
                    pantalla.Show();
                    sesionActual.setUsuario(usu);
                    succes = true;
                }
            }
            if (!succes)
            {
                MessageBox.Show("Usuario o contraseña incorrecta","ERROR");
            }

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Ej: Admin")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Ej: Admin";
                txtUsuario.ForeColor = Color.Silver;
            }
        }
    }
}
