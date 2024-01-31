using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Mail;


namespace Gestion_de_RT
{
    public partial class PantallaRegistrarReserva : Form
    {
        private GestorRegistrarReserva gestor;
        private List<Tuple<string, DateTime, string>> datosTurnos;

        public PantallaRegistrarReserva(GestorRegistrarReserva gestor)
        {
            InitializeComponent();
            this.gestor = gestor;
            gestor.setPantalla(this);

        }
        public List<Tuple<string, DateTime, string>> getDatosTurnos()
        {
            return this.datosTurnos;
        }
        private void btnNvaReserva_Click(object sender, EventArgs e)
        {
            this.habilitar();
        }

        /*
         * Método que habilita la pantalla para una nueva reserva, habilitando y creando cada atributo de la interfaz.
         */
        public void habilitar()
        {
            gestor.nuevaReserva();
            lblTiposRT.Visible = true;
            cmbTiposRT.Visible = true;
            //btnNvaReserva.Visible = false;
            btnNvaReserva.Enabled = false;
            btnSelecTipoRT.Visible = true;

            btnSelecRT.Enabled = true;
            btnSelecTipoRT.Enabled = true;
            cmbRTs.Enabled = true;
            lblCheckRT.Visible = false;
            cmbTiposRT.Enabled = true;
            lblCheckTipoRT.Visible = false;
            dgvCalendario.Enabled = true;

            lblRTs.Visible = true;
            cmbRTs.Visible = true;
            lblEspecificacion.Visible = true;
            btnSelecRT.Visible = true;
            lblRTs.Enabled = false;
            cmbRTs.Enabled = false;
            lblEspecificacion.Enabled = false;
            btnSelecRT.Enabled = false;

            groupBox1.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            groupBox1.Enabled = false;
            label1.Visible = true;

        }

        /*
        * Método que limpia las selecciones una vez finalizada una nueva reserva.
        */
        public void limpiar()
        {
            DataTable dt = (DataTable)dgvCalendario.DataSource;
            dt.Clear();

            groupBox1.Enabled = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            lblTurnoConfirmado.Visible = false;
            lblTurnoConfirmado2.Visible = false;
        }

        /*
        * Método que recibe la lista con los tipos de recurso tecnológico y los carga en un combo box.
        */
        public void listarTiposRT(List<string> tiposRT)
        {
            cmbTiposRT.DataSource = tiposRT;
        }

        private void btnSelecTipoRT_Click(object sender, EventArgs e)
        {
            this.seleccionTipoRT();
        }

        /*
        * Método utilizado cuando el usuario selecciona un tipo de RT y envia la selección al gestor.
        */
        public void seleccionTipoRT()
        {
            gestor.tomarSeleccionTipoRT(cmbTiposRT.SelectedItem.ToString());
            //btnSelecTipoRT.Enabled = false;
            //cmbTiposRT.Enabled = false;
            lblCheckTipoRT.Visible = true;
        }

        /*
        * Método que recibe la lista con los recursos tecnológicos y los carga en un combo box.
        */
        public void listarRT(List<Tuple<int, string, string>> datosRTs)
        {
            lblRTs.Enabled = true;
            cmbRTs.Enabled = true;
            lblEspecificacion.Enabled = true;
            btnSelecRT.Enabled = true;
            cmbRTs.DataSource = datosRTs;
        }

        /*
        * Método utilizado cuando el usuario selecciona un recurso tecnológico y envia la selección al gestor.
        */
        public void seleccionRT()
        {
            gestor.tomarSeleccionRT(int.Parse(cmbRTs.SelectedItem.ToString().Substring(1, 3)));
            btnSelecRT.Enabled = false;
            btnSelecTipoRT.Enabled = false;
            cmbRTs.Enabled = false;
            lblCheckRT.Visible = true;
            cmbTiposRT.Enabled = false;
        }

        private void btnSelecRT_Click(object sender, EventArgs e)
        {
            this.seleccionRT();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked)
            {
                MessageBox.Show("Notificación enviada, Muchas gracias!");
                //Application.Exit();
                this.habilitar();
                this.limpiar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una forma de notificacion!");
            }


        }

        /*
        * Método recibe si el cientifico pertenece al CI del recurso tecnológico y muestra un mensaje.
        */
        public void mostrarMensajePertenencia(bool op)
        {
            if (op)
            {
                MessageBox.Show("El cientifico pertenece al CI del RT", "Important!");
            }
            else
            {
                MessageBox.Show("El cientifico no pertenece al CI del RT", "Warning!");
            }

        }

        /*
        * Método que recibe la lista de turnos y carga la grilla segun su fecha y estado.
        */
        public void presentarTurnos(List<Tuple<string, DateTime, string>> datosTurnos)
        {
            List<string> turnosDispo = new List<string>();
            this.datosTurnos = datosTurnos;
            foreach (Tuple<string, DateTime, string> turno in datosTurnos)
            {
                if (turno.Item3.Equals("Disponible"))
                {
                    //   turnosDispo.Add(turno.Item2.ToString());
                    turnosDispo.Add(turno.Item2.ToString("dd/M/yyyy"));
                }
            }

            DataTable tabla = new DataTable();

            List<string> dias = new List<string>();
            dias.Add("Lunes");
            dias.Add("Martes");
            dias.Add("Miércoles");
            dias.Add("Jueves");
            dias.Add("Viernes");
            dias.Add("Sábado");
            dias.Add("Domingo");


            for (int i = 0; i < 7; i++)
            {
                tabla.Columns.Add(dias[i].ToString(), typeof(string));
            }

            DateTime fechaInicial = DateTime.Now.Date;
            for (int i = 0; i < 6; i++)
            {
                DataRow dr = tabla.NewRow();
                tabla.Rows.Add(dr);
            }
            int indice = 0;
            for (DateTime d = fechaInicial; d < fechaInicial.AddMonths(1); d = d.AddDays(1))
            {
                // d.ToString("dddd", new CultureInfo("es-ES"))

                tabla.Rows[indice][d.ToString("dddd", new CultureInfo("es-ES"))] = d.Date.ToString("dd/M/yyyy");
                if (d.ToString("dddd", new CultureInfo("es-ES")).Equals("domingo"))
                {
                    indice++;
                }
            }

            dgvCalendario.DataSource = tabla;
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)
                {
                    if (turnosDispo.Contains(dgvCalendario[c, f].Value.ToString()))
                    {
                        dgvCalendario[c, f].Style.BackColor = Color.FromArgb(7, 83, 217);
                    }
                    else
                    {
                        dgvCalendario[c, f].Style.BackColor = Color.FromArgb(230, 47, 8);
                    }

                }
            }
            dgvCalendario.ClearSelection();

        }
        private void dgvTurnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCalendario.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.FromArgb(230, 47, 8))
            {
                MessageBox.Show("Error - Este día no hay turnos disponibles");
            }
            else
            {
                //MessageBox.Show("Usted escogio el turno " + dgvCalendario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                this.Enabled = false;

                List<Tuple<string, DateTime, string>> turnosDia = new List<Tuple<string, DateTime, string>>();
                foreach (Tuple<string, DateTime, string> turno in this.datosTurnos)
                {
                    if (turno.Item2.ToString("dd/M/yyyy") == dgvCalendario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                    {
                        turnosDia.Add(turno);
                    }
                }
                popUp turnos = new popUp(this, turnosDia);
                //turnos.Show();
            }
        }

        public void seleccionTurno(DateTime fechaTurno)
        {
            this.gestor.tomarSeleccionTurno(fechaTurno);
            this.Enabled = true;
        }

        /*
        * Método que pide la confirmación de la reserva del turno, muestra los datos de la misma, y prepara la interfaz para una nueva reserva.
        */
        public void pedirConfirmacion(DateTime fechaTurno, List<String> formasNotif)
        {

            DialogResult resultado = MessageBox.Show("Desea confirmar el turno con fecha " + fechaTurno.ToString(), "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (resultado == DialogResult.OK)
            {
                MessageBox.Show("Turno seleccionado con exito!");
                gestor.tomarConfirmacion(fechaTurno);
                dgvCalendario.Enabled = false;
                lblTurnoConfirmado.Text = "Turno para el día y hora " + fechaTurno.ToString() ;
                lblTurnoConfirmado.Visible = true;
                lblTurnoConfirmado2.Text = "Para el recurso " + cmbRTs.SelectedItem.ToString() + " confirmado con éxito!";
                lblTurnoConfirmado2.Visible = true;
                label1.Visible = true;
                groupBox1.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                btnSalir.Enabled = true;
                groupBox1.Enabled = true;

            }
            else
            {
                MessageBox.Show("Cancelo la confirmación!");
            }
        }

        private void PantallaRegistrarReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void PantallaRegistrarReserva_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
