namespace Watch7
{
    partial class FormDeleteCPU
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.comboBoxEquipament = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxInstalations = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxZonas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCPUs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(209, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "Error al eliminar CPU.";
            this.label2.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(305, 261);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(117, 34);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "CANCELAR";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(131, 261);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(117, 34);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "ELIMINAR";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // comboBoxEquipament
            // 
            this.comboBoxEquipament.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEquipament.FormattingEnabled = true;
            this.comboBoxEquipament.Location = new System.Drawing.Point(180, 121);
            this.comboBoxEquipament.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxEquipament.Name = "comboBoxEquipament";
            this.comboBoxEquipament.Size = new System.Drawing.Size(303, 25);
            this.comboBoxEquipament.TabIndex = 2;
            this.comboBoxEquipament.SelectedIndexChanged += new System.EventHandler(this.comboBoxEquipament_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 16);
            this.label5.TabIndex = 45;
            this.label5.Text = "Selección del equipo: ";
            // 
            // comboBoxInstalations
            // 
            this.comboBoxInstalations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxInstalations.FormattingEnabled = true;
            this.comboBoxInstalations.Location = new System.Drawing.Point(180, 71);
            this.comboBoxInstalations.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxInstalations.Name = "comboBoxInstalations";
            this.comboBoxInstalations.Size = new System.Drawing.Size(303, 25);
            this.comboBoxInstalations.TabIndex = 1;
            this.comboBoxInstalations.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstalations_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Selección de instalación: ";
            // 
            // comboBoxZonas
            // 
            this.comboBoxZonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxZonas.FormattingEnabled = true;
            this.comboBoxZonas.Location = new System.Drawing.Point(180, 22);
            this.comboBoxZonas.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxZonas.Name = "comboBoxZonas";
            this.comboBoxZonas.Size = new System.Drawing.Size(303, 25);
            this.comboBoxZonas.TabIndex = 0;
            this.comboBoxZonas.SelectedIndexChanged += new System.EventHandler(this.comboBoxZonas_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Selección de zona: ";
            // 
            // comboBoxCPUs
            // 
            this.comboBoxCPUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCPUs.FormattingEnabled = true;
            this.comboBoxCPUs.Location = new System.Drawing.Point(180, 175);
            this.comboBoxCPUs.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCPUs.Name = "comboBoxCPUs";
            this.comboBoxCPUs.Size = new System.Drawing.Size(303, 25);
            this.comboBoxCPUs.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Selección de la CPU: ";
            // 
            // FormDeleteCPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 320);
            this.Controls.Add(this.comboBoxCPUs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.comboBoxEquipament);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxInstalations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxZonas);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDeleteCPU";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ELIMINAR CPU";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox comboBoxEquipament;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxInstalations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxZonas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCPUs;
        private System.Windows.Forms.Label label1;
    }
}