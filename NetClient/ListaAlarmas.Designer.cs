namespace NetClient
{
    partial class ListaAlarmas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblfechafinal = new System.Windows.Forms.Label();
            this.lblfechainicio = new System.Windows.Forms.Label();
            this.dateTimeFinal = new System.Windows.Forms.DateTimePicker();
            this.dateTimeInicio = new System.Windows.Forms.DateTimePicker();
            this.lblRegla = new System.Windows.Forms.Label();
            this.CmdRules = new System.Windows.Forms.ComboBox();
            this.LblEmpresa = new System.Windows.Forms.Label();
            this.cmdEmpresas = new System.Windows.Forms.ComboBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.GrpDatos = new System.Windows.Forms.GroupBox();
            this.GridAlarmas = new System.Windows.Forms.DataGridView();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.checkAllRules = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.GrpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridAlarmas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkAllRules);
            this.groupBox1.Controls.Add(this.lblfechafinal);
            this.groupBox1.Controls.Add(this.lblfechainicio);
            this.groupBox1.Controls.Add(this.dateTimeFinal);
            this.groupBox1.Controls.Add(this.dateTimeInicio);
            this.groupBox1.Controls.Add(this.lblRegla);
            this.groupBox1.Controls.Add(this.CmdRules);
            this.groupBox1.Controls.Add(this.LblEmpresa);
            this.groupBox1.Controls.Add(this.cmdEmpresas);
            this.groupBox1.Controls.Add(this.btnProcesar);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(939, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Filtros";
            // 
            // lblfechafinal
            // 
            this.lblfechafinal.AutoSize = true;
            this.lblfechafinal.Location = new System.Drawing.Point(222, 70);
            this.lblfechafinal.Name = "lblfechafinal";
            this.lblfechafinal.Size = new System.Drawing.Size(62, 13);
            this.lblfechafinal.TabIndex = 8;
            this.lblfechafinal.Text = "Fecha Final";
            // 
            // lblfechainicio
            // 
            this.lblfechainicio.AutoSize = true;
            this.lblfechainicio.Location = new System.Drawing.Point(6, 70);
            this.lblfechainicio.Name = "lblfechainicio";
            this.lblfechainicio.Size = new System.Drawing.Size(65, 13);
            this.lblfechainicio.TabIndex = 7;
            this.lblfechainicio.Text = "Fecha Inicio";
            // 
            // dateTimeFinal
            // 
            this.dateTimeFinal.Location = new System.Drawing.Point(225, 84);
            this.dateTimeFinal.Name = "dateTimeFinal";
            this.dateTimeFinal.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFinal.TabIndex = 6;
            // 
            // dateTimeInicio
            // 
            this.dateTimeInicio.Location = new System.Drawing.Point(9, 84);
            this.dateTimeInicio.Name = "dateTimeInicio";
            this.dateTimeInicio.Size = new System.Drawing.Size(200, 20);
            this.dateTimeInicio.TabIndex = 5;
            // 
            // lblRegla
            // 
            this.lblRegla.AutoSize = true;
            this.lblRegla.Location = new System.Drawing.Point(222, 19);
            this.lblRegla.Name = "lblRegla";
            this.lblRegla.Size = new System.Drawing.Size(35, 13);
            this.lblRegla.TabIndex = 4;
            this.lblRegla.Text = "Regla";
            // 
            // CmdRules
            // 
            this.CmdRules.FormattingEnabled = true;
            this.CmdRules.Location = new System.Drawing.Point(225, 37);
            this.CmdRules.Name = "CmdRules";
            this.CmdRules.Size = new System.Drawing.Size(283, 21);
            this.CmdRules.TabIndex = 3;
            // 
            // LblEmpresa
            // 
            this.LblEmpresa.AutoSize = true;
            this.LblEmpresa.Location = new System.Drawing.Point(6, 19);
            this.LblEmpresa.Name = "LblEmpresa";
            this.LblEmpresa.Size = new System.Drawing.Size(48, 13);
            this.LblEmpresa.TabIndex = 2;
            this.LblEmpresa.Text = "Empresa";
            // 
            // cmdEmpresas
            // 
            this.cmdEmpresas.FormattingEnabled = true;
            this.cmdEmpresas.Location = new System.Drawing.Point(6, 38);
            this.cmdEmpresas.Name = "cmdEmpresas";
            this.cmdEmpresas.Size = new System.Drawing.Size(201, 21);
            this.cmdEmpresas.TabIndex = 1;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(480, 81);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(133, 23);
            this.btnProcesar.TabIndex = 0;
            this.btnProcesar.Text = "Obtener Datos Alarma";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // GrpDatos
            // 
            this.GrpDatos.Controls.Add(this.GridAlarmas);
            this.GrpDatos.Location = new System.Drawing.Point(21, 165);
            this.GrpDatos.Name = "GrpDatos";
            this.GrpDatos.Size = new System.Drawing.Size(951, 539);
            this.GrpDatos.TabIndex = 1;
            this.GrpDatos.TabStop = false;
            this.GrpDatos.Text = "Datos";
            // 
            // GridAlarmas
            // 
            this.GridAlarmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridAlarmas.Location = new System.Drawing.Point(9, 20);
            this.GridAlarmas.Name = "GridAlarmas";
            this.GridAlarmas.Size = new System.Drawing.Size(930, 513);
            this.GridAlarmas.TabIndex = 0;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(30, 146);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(57, 13);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "lblMensaje";
            // 
            // checkAllRules
            // 
            this.checkAllRules.AutoSize = true;
            this.checkAllRules.Location = new System.Drawing.Point(525, 38);
            this.checkAllRules.Name = "checkAllRules";
            this.checkAllRules.Size = new System.Drawing.Size(64, 17);
            this.checkAllRules.TabIndex = 8;
            this.checkAllRules.Text = "AllRules";
            this.checkAllRules.UseVisualStyleBackColor = true;
            this.checkAllRules.CheckedChanged += new System.EventHandler(this.checkAllRules_CheckedChanged);
            // 
            // ListaAlarmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 716);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.GrpDatos);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListaAlarmas";
            this.Text = "Listado Alarmas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GrpDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridAlarmas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblEmpresa;
        private System.Windows.Forms.ComboBox cmdEmpresas;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label lblfechafinal;
        private System.Windows.Forms.Label lblfechainicio;
        private System.Windows.Forms.DateTimePicker dateTimeFinal;
        private System.Windows.Forms.DateTimePicker dateTimeInicio;
        private System.Windows.Forms.Label lblRegla;
        private System.Windows.Forms.ComboBox CmdRules;
        private System.Windows.Forms.GroupBox GrpDatos;
        private System.Windows.Forms.DataGridView GridAlarmas;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.CheckBox checkAllRules;
    }
}