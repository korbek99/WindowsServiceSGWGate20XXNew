namespace NetClient
{
    partial class LogErrores
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
            this.GRBDatosFiltros = new System.Windows.Forms.GroupBox();
            this.checkAllRules = new System.Windows.Forms.CheckBox();
            this.dateTimeFin = new System.Windows.Forms.DateTimePicker();
            this.dateTimeInicio = new System.Windows.Forms.DateTimePicker();
            this.btnprocesar = new System.Windows.Forms.Button();
            this.lblTypeRules = new System.Windows.Forms.Label();
            this.DDlTypeRules = new System.Windows.Forms.ComboBox();
            this.LblCustomers = new System.Windows.Forms.Label();
            this.DDlCustomers = new System.Windows.Forms.ComboBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GridData = new System.Windows.Forms.DataGridView();
            this.GRBDatosFiltros.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).BeginInit();
            this.SuspendLayout();
            // 
            // GRBDatosFiltros
            // 
            this.GRBDatosFiltros.Controls.Add(this.checkAllRules);
            this.GRBDatosFiltros.Controls.Add(this.dateTimeFin);
            this.GRBDatosFiltros.Controls.Add(this.dateTimeInicio);
            this.GRBDatosFiltros.Controls.Add(this.btnprocesar);
            this.GRBDatosFiltros.Controls.Add(this.lblTypeRules);
            this.GRBDatosFiltros.Controls.Add(this.DDlTypeRules);
            this.GRBDatosFiltros.Controls.Add(this.LblCustomers);
            this.GRBDatosFiltros.Controls.Add(this.DDlCustomers);
            this.GRBDatosFiltros.Location = new System.Drawing.Point(12, 12);
            this.GRBDatosFiltros.Name = "GRBDatosFiltros";
            this.GRBDatosFiltros.Size = new System.Drawing.Size(681, 100);
            this.GRBDatosFiltros.TabIndex = 1;
            this.GRBDatosFiltros.TabStop = false;
            this.GRBDatosFiltros.Text = "Datos Filtros";
            // 
            // checkAllRules
            // 
            this.checkAllRules.AutoSize = true;
            this.checkAllRules.Location = new System.Drawing.Point(479, 38);
            this.checkAllRules.Name = "checkAllRules";
            this.checkAllRules.Size = new System.Drawing.Size(64, 17);
            this.checkAllRules.TabIndex = 7;
            this.checkAllRules.Text = "AllRules";
            this.checkAllRules.UseVisualStyleBackColor = true;
            // 
            // dateTimeFin
            // 
            this.dateTimeFin.Location = new System.Drawing.Point(213, 69);
            this.dateTimeFin.Name = "dateTimeFin";
            this.dateTimeFin.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFin.TabIndex = 6;
            // 
            // dateTimeInicio
            // 
            this.dateTimeInicio.Location = new System.Drawing.Point(6, 69);
            this.dateTimeInicio.Name = "dateTimeInicio";
            this.dateTimeInicio.Size = new System.Drawing.Size(200, 20);
            this.dateTimeInicio.TabIndex = 5;
            // 
            // btnprocesar
            // 
            this.btnprocesar.Location = new System.Drawing.Point(444, 66);
            this.btnprocesar.Name = "btnprocesar";
            this.btnprocesar.Size = new System.Drawing.Size(155, 23);
            this.btnprocesar.TabIndex = 4;
            this.btnprocesar.Text = "Procesar";
            this.btnprocesar.UseVisualStyleBackColor = true;
            // 
            // lblTypeRules
            // 
            this.lblTypeRules.AutoSize = true;
            this.lblTypeRules.Location = new System.Drawing.Point(255, 18);
            this.lblTypeRules.Name = "lblTypeRules";
            this.lblTypeRules.Size = new System.Drawing.Size(56, 13);
            this.lblTypeRules.TabIndex = 3;
            this.lblTypeRules.Text = "Type Error";
            // 
            // DDlTypeRules
            // 
            this.DDlTypeRules.FormattingEnabled = true;
            this.DDlTypeRules.Location = new System.Drawing.Point(255, 34);
            this.DDlTypeRules.Name = "DDlTypeRules";
            this.DDlTypeRules.Size = new System.Drawing.Size(217, 21);
            this.DDlTypeRules.TabIndex = 2;
            // 
            // LblCustomers
            // 
            this.LblCustomers.AutoSize = true;
            this.LblCustomers.Location = new System.Drawing.Point(6, 19);
            this.LblCustomers.Name = "LblCustomers";
            this.LblCustomers.Size = new System.Drawing.Size(44, 13);
            this.LblCustomers.TabIndex = 1;
            this.LblCustomers.Text = "Sistema";
            // 
            // DDlCustomers
            // 
            this.DDlCustomers.FormattingEnabled = true;
            this.DDlCustomers.Location = new System.Drawing.Point(6, 35);
            this.DDlCustomers.Name = "DDlCustomers";
            this.DDlCustomers.Size = new System.Drawing.Size(220, 21);
            this.DDlCustomers.TabIndex = 0;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(15, 118);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(57, 13);
            this.lblMensaje.TabIndex = 5;
            this.lblMensaje.Text = "lblMensaje";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GridData);
            this.groupBox2.Location = new System.Drawing.Point(12, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(963, 524);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Mapa";
            // 
            // GridData
            // 
            this.GridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridData.Location = new System.Drawing.Point(9, 19);
            this.GridData.Name = "GridData";
            this.GridData.Size = new System.Drawing.Size(948, 499);
            this.GridData.TabIndex = 0;
            // 
            // LogErrores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 681);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GRBDatosFiltros);
            this.Name = "LogErrores";
            this.Text = "LogErrores";
            this.GRBDatosFiltros.ResumeLayout(false);
            this.GRBDatosFiltros.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GRBDatosFiltros;
        private System.Windows.Forms.CheckBox checkAllRules;
        private System.Windows.Forms.DateTimePicker dateTimeFin;
        private System.Windows.Forms.DateTimePicker dateTimeInicio;
        private System.Windows.Forms.Button btnprocesar;
        private System.Windows.Forms.Label lblTypeRules;
        private System.Windows.Forms.ComboBox DDlTypeRules;
        private System.Windows.Forms.Label LblCustomers;
        private System.Windows.Forms.ComboBox DDlCustomers;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GridData;
    }
}