
namespace Gestion_de_RT
{
    partial class popUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grillaTurnos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaTurnos
            // 
            this.grillaTurnos.AllowUserToAddRows = false;
            this.grillaTurnos.AllowUserToDeleteRows = false;
            this.grillaTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaTurnos.Location = new System.Drawing.Point(0, 0);
            this.grillaTurnos.MultiSelect = false;
            this.grillaTurnos.Name = "grillaTurnos";
            this.grillaTurnos.ReadOnly = true;
            this.grillaTurnos.RowHeadersWidth = 51;
            this.grillaTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaTurnos.Size = new System.Drawing.Size(358, 90);
            this.grillaTurnos.TabIndex = 0;
            this.grillaTurnos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaTurnos_CellContentDoubleClick);
            // 
            // popUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 90);
            this.Controls.Add(this.grillaTurnos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "popUp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.popUp_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grillaTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaTurnos;
    }
}