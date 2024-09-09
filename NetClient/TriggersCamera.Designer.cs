namespace NetClient
{
    partial class TriggersCamera
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
            this.ListSentNextiva = new System.Windows.Forms.ListBox();
            this.lbAlarmlistBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ListSentNextiva
            // 
            this.ListSentNextiva.FormattingEnabled = true;
            this.ListSentNextiva.Location = new System.Drawing.Point(23, 119);
            this.ListSentNextiva.Name = "ListSentNextiva";
            this.ListSentNextiva.Size = new System.Drawing.Size(617, 82);
            this.ListSentNextiva.TabIndex = 25;
            // 
            // lbAlarmlistBox
            // 
            this.lbAlarmlistBox.FormattingEnabled = true;
            this.lbAlarmlistBox.Location = new System.Drawing.Point(21, 34);
            this.lbAlarmlistBox.Name = "lbAlarmlistBox";
            this.lbAlarmlistBox.Size = new System.Drawing.Size(619, 69);
            this.lbAlarmlistBox.TabIndex = 24;
            // 
            // TriggersCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 236);
            this.Controls.Add(this.ListSentNextiva);
            this.Controls.Add(this.lbAlarmlistBox);
            this.Name = "TriggersCamera";
            this.Text = "TriggersCamera";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListSentNextiva;
        private System.Windows.Forms.ListBox lbAlarmlistBox;
    }
}