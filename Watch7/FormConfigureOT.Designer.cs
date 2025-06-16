namespace Watch7
{
    partial class FormConfigureOT
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
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxMask = new System.Windows.Forms.TextBox();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelNOK = new System.Windows.Forms.Label();
            this.labelOK = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPort);
            this.groupBox1.Controls.Add(this.textBoxMask);
            this.groupBox1.Controls.Add(this.textBoxIp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(316, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  DATOS DE RED  ";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(128, 123);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(163, 23);
            this.textBoxPort.TabIndex = 2;
            // 
            // textBoxMask
            // 
            this.textBoxMask.Location = new System.Drawing.Point(128, 80);
            this.textBoxMask.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMask.Name = "textBoxMask";
            this.textBoxMask.Size = new System.Drawing.Size(163, 23);
            this.textBoxMask.TabIndex = 1;
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(128, 42);
            this.textBoxIp.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(163, 23);
            this.textBoxIp.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Puerta de enlace:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mascara:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP: ";
            // 
            // buttonTest
            // 
            this.buttonTest.Enabled = false;
            this.buttonTest.Location = new System.Drawing.Point(65, 245);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(117, 34);
            this.buttonTest.TabIndex = 4;
            this.buttonTest.Text = "TEST CONEXIÓN";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(395, 245);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(117, 34);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "CERRAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(232, 245);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(117, 34);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "GUARDAR";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelNOK
            // 
            this.labelNOK.AutoSize = true;
            this.labelNOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNOK.ForeColor = System.Drawing.Color.Crimson;
            this.labelNOK.Location = new System.Drawing.Point(192, 209);
            this.labelNOK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNOK.Name = "labelNOK";
            this.labelNOK.Size = new System.Drawing.Size(200, 20);
            this.labelNOK.TabIndex = 23;
            this.labelNOK.Text = "ERROR DE CONEXIÓN";
            this.labelNOK.Visible = false;
            // 
            // labelOK
            // 
            this.labelOK.AutoSize = true;
            this.labelOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOK.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelOK.Location = new System.Drawing.Point(221, 209);
            this.labelOK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOK.Name = "labelOK";
            this.labelOK.Size = new System.Drawing.Size(130, 20);
            this.labelOK.TabIndex = 22;
            this.labelOK.Text = "CONEXIÓN OK";
            this.labelOK.Visible = false;
            // 
            // FormConfigureOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 297);
            this.Controls.Add(this.labelNOK);
            this.Controls.Add(this.labelOK);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfigureOT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIGURAR RED";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxMask;
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelNOK;
        private System.Windows.Forms.Label labelOK;
    }
}