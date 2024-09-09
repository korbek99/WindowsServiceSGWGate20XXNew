namespace WindowsServiceNextiva
{
    partial class VideoWindow
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlVideo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlVideo
            // 
            this.pnlVideo.Location = new System.Drawing.Point(3, 3);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(192, 202);
            this.pnlVideo.TabIndex = 2;
            // 
            // VideoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlVideo);
            this.Name = "VideoWindow";
            this.Size = new System.Drawing.Size(198, 208);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlVideo;
    }
}
