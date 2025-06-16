namespace Watch7
{
    partial class FormConfigureDB
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.labelOK = new System.Windows.Forms.Label();
            this.labelNOK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(150, 30);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(587, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cadena de conexión:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(490, 125);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(117, 34);
            this.buttonCancelar.TabIndex = 3;
            this.buttonCancelar.Text = "CERRAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(318, 125);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(117, 34);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "GUARDAR";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Enabled = false;
            this.buttonTest.Location = new System.Drawing.Point(137, 125);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(117, 34);
            this.buttonTest.TabIndex = 2;
            this.buttonTest.Text = "TEST CONEXIÓN";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // labelOK
            // 
            this.labelOK.AutoSize = true;
            this.labelOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOK.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelOK.Location = new System.Drawing.Point(311, 80);
            this.labelOK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOK.Name = "labelOK";
            this.labelOK.Size = new System.Drawing.Size(130, 20);
            this.labelOK.TabIndex = 19;
            this.labelOK.Text = "CONEXIÓN OK";
            this.labelOK.Visible = false;
            // 
            // labelNOK
            // 
            this.labelNOK.AutoSize = true;
            this.labelNOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNOK.ForeColor = System.Drawing.Color.Crimson;
            this.labelNOK.Location = new System.Drawing.Point(282, 80);
            this.labelNOK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNOK.Name = "labelNOK";
            this.labelNOK.Size = new System.Drawing.Size(200, 20);
            this.labelNOK.TabIndex = 20;
            this.labelNOK.Text = "ERROR DE CONEXIÓN";
            this.labelNOK.Visible = false;
            // 
            // FormConfigureDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 182);
            this.Controls.Add(this.labelNOK);
            this.Controls.Add(this.labelOK);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfigureDB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIGURAR ACCESO A BASE DE DATOS";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelOK;
        private System.Windows.Forms.Label labelNOK;
    }
}