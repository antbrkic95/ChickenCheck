namespace ChickenCheck
{
    partial class FormaDodavanjeCjepiva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaDodavanjeCjepiva));
            this.actionUnesiCjepivo = new System.Windows.Forms.Button();
            this.inputFormaDodavanjeCjepivaNaziv = new System.Windows.Forms.TextBox();
            this.inputFormaDodavanjeCjepivaOpis = new System.Windows.Forms.TextBox();
            this.inputFormaDodavanjeCjepivaVrsta = new System.Windows.Forms.TextBox();
            this.outputFormaDodavanjeCjepivaNaziv = new System.Windows.Forms.Label();
            this.outputFormaDodavanjeCjepivaVrsta = new System.Windows.Forms.Label();
            this.outputFormaDodavanjeCjepivaOpis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // actionUnesiCjepivo
            // 
            this.actionUnesiCjepivo.Location = new System.Drawing.Point(58, 231);
            this.actionUnesiCjepivo.Name = "actionUnesiCjepivo";
            this.actionUnesiCjepivo.Size = new System.Drawing.Size(163, 41);
            this.actionUnesiCjepivo.TabIndex = 0;
            this.actionUnesiCjepivo.Text = "Unesi cjepivo";
            this.actionUnesiCjepivo.UseVisualStyleBackColor = true;
            this.actionUnesiCjepivo.Click += new System.EventHandler(this.actionUnesiCjepivo_Click);
            // 
            // inputFormaDodavanjeCjepivaNaziv
            // 
            this.inputFormaDodavanjeCjepivaNaziv.Location = new System.Drawing.Point(36, 34);
            this.inputFormaDodavanjeCjepivaNaziv.Name = "inputFormaDodavanjeCjepivaNaziv";
            this.inputFormaDodavanjeCjepivaNaziv.Size = new System.Drawing.Size(208, 20);
            this.inputFormaDodavanjeCjepivaNaziv.TabIndex = 1;
            // 
            // inputFormaDodavanjeCjepivaOpis
            // 
            this.inputFormaDodavanjeCjepivaOpis.Location = new System.Drawing.Point(36, 114);
            this.inputFormaDodavanjeCjepivaOpis.Multiline = true;
            this.inputFormaDodavanjeCjepivaOpis.Name = "inputFormaDodavanjeCjepivaOpis";
            this.inputFormaDodavanjeCjepivaOpis.Size = new System.Drawing.Size(208, 95);
            this.inputFormaDodavanjeCjepivaOpis.TabIndex = 2;
            // 
            // inputFormaDodavanjeCjepivaVrsta
            // 
            this.inputFormaDodavanjeCjepivaVrsta.Location = new System.Drawing.Point(36, 74);
            this.inputFormaDodavanjeCjepivaVrsta.Name = "inputFormaDodavanjeCjepivaVrsta";
            this.inputFormaDodavanjeCjepivaVrsta.Size = new System.Drawing.Size(208, 20);
            this.inputFormaDodavanjeCjepivaVrsta.TabIndex = 3;
            // 
            // outputFormaDodavanjeCjepivaNaziv
            // 
            this.outputFormaDodavanjeCjepivaNaziv.AutoSize = true;
            this.outputFormaDodavanjeCjepivaNaziv.Location = new System.Drawing.Point(34, 18);
            this.outputFormaDodavanjeCjepivaNaziv.Name = "outputFormaDodavanjeCjepivaNaziv";
            this.outputFormaDodavanjeCjepivaNaziv.Size = new System.Drawing.Size(37, 13);
            this.outputFormaDodavanjeCjepivaNaziv.TabIndex = 4;
            this.outputFormaDodavanjeCjepivaNaziv.Text = "Naziv:";
            // 
            // outputFormaDodavanjeCjepivaVrsta
            // 
            this.outputFormaDodavanjeCjepivaVrsta.AutoSize = true;
            this.outputFormaDodavanjeCjepivaVrsta.Location = new System.Drawing.Point(34, 58);
            this.outputFormaDodavanjeCjepivaVrsta.Name = "outputFormaDodavanjeCjepivaVrsta";
            this.outputFormaDodavanjeCjepivaVrsta.Size = new System.Drawing.Size(34, 13);
            this.outputFormaDodavanjeCjepivaVrsta.TabIndex = 5;
            this.outputFormaDodavanjeCjepivaVrsta.Text = "Vrsta:";
            // 
            // outputFormaDodavanjeCjepivaOpis
            // 
            this.outputFormaDodavanjeCjepivaOpis.AutoSize = true;
            this.outputFormaDodavanjeCjepivaOpis.Location = new System.Drawing.Point(34, 98);
            this.outputFormaDodavanjeCjepivaOpis.Name = "outputFormaDodavanjeCjepivaOpis";
            this.outputFormaDodavanjeCjepivaOpis.Size = new System.Drawing.Size(31, 13);
            this.outputFormaDodavanjeCjepivaOpis.TabIndex = 6;
            this.outputFormaDodavanjeCjepivaOpis.Text = "Opis:";
            // 
            // FormaDodavanjeCjepiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 300);
            this.Controls.Add(this.outputFormaDodavanjeCjepivaOpis);
            this.Controls.Add(this.outputFormaDodavanjeCjepivaVrsta);
            this.Controls.Add(this.outputFormaDodavanjeCjepivaNaziv);
            this.Controls.Add(this.inputFormaDodavanjeCjepivaVrsta);
            this.Controls.Add(this.inputFormaDodavanjeCjepivaOpis);
            this.Controls.Add(this.inputFormaDodavanjeCjepivaNaziv);
            this.Controls.Add(this.actionUnesiCjepivo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormaDodavanjeCjepiva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodavanje cjepiva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button actionUnesiCjepivo;
        private System.Windows.Forms.TextBox inputFormaDodavanjeCjepivaNaziv;
        private System.Windows.Forms.TextBox inputFormaDodavanjeCjepivaOpis;
        private System.Windows.Forms.TextBox inputFormaDodavanjeCjepivaVrsta;
        private System.Windows.Forms.Label outputFormaDodavanjeCjepivaNaziv;
        private System.Windows.Forms.Label outputFormaDodavanjeCjepivaVrsta;
        private System.Windows.Forms.Label outputFormaDodavanjeCjepivaOpis;
    }
}