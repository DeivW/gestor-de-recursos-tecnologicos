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
    public partial class popUp : Form
    {
        PantallaRegistrarReserva pp;
        List<Tuple<string, DateTime, string>> turnosDia;
        public popUp(PantallaRegistrarReserva pp, List<Tuple<string, DateTime, string>> turnosDia)
        {
            this.pp = pp;
            this.turnosDia = turnosDia;
            InitializeComponent();
            this.Show();
            grillaTurnos.DataSource = turnosDia;
            grillaTurnos.Columns[0].HeaderText = "Día";
            grillaTurnos.Columns[1].HeaderText = "Fecha y Hora";
            grillaTurnos.Columns[2].HeaderText = "Estado";
            int filas = grillaTurnos.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                if (grillaTurnos[2, i].Value.ToString().Equals("Disponible"))
                {
                    //grillaTurnos[2,i].Style.BackColor = Color.FromArgb(7, 83, 217);
                    grillaTurnos.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(7, 83, 217);
                }
                else
                {
                    grillaTurnos.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(230, 47, 8);
                    
                }
            }
            grillaTurnos.ClearSelection();
        }

        private void popUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            pp.Enabled = true;
        }

        private void grillaTurnos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (grillaTurnos.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.FromArgb(230, 47, 8))
            if(grillaTurnos.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.FromArgb(230, 47, 8))
            {
                MessageBox.Show("Ese turno no está disponible!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pp.seleccionTurno(DateTime.Parse(grillaTurnos.Rows[e.RowIndex].Cells[1].Value.ToString()));
                this.Hide();
                
                
            }
        }
    }
}
