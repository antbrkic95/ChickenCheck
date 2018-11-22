namespace ChickenCheck
{
    partial class FormaEvidencijaCijepljenja
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaEvidencijaCijepljenja));
            this.outputFormaEvidencijaCijepljenjaDatum = new System.Windows.Forms.Label();
            this.actionFormaEvidencijaCijepljenjaUnesiCijepljenje = new System.Windows.Forms.Button();
            this.inputFormaEvidencijaCijepljenjaDatum = new System.Windows.Forms.DateTimePicker();
            this.inputFormaEvidencijaCijepljenjaCjepivo = new System.Windows.Forms.ComboBox();
            this.cjepivoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.outputFormaEvidencijaCijepljenjaTurnus = new System.Windows.Forms.Label();
            this.outputFormaEvidencijaCijepljenjaCjepivo = new System.Windows.Forms.Label();
            this.kokosiTurnusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inputFormaEvidencijaCjepljenjaTurnus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cjepivoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kokosiTurnusBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // outputFormaEvidencijaCijepljenjaDatum
            // 
            this.outputFormaEvidencijaCijepljenjaDatum.AutoSize = true;
            this.outputFormaEvidencijaCijepljenjaDatum.Location = new System.Drawing.Point(28, 99);
            this.outputFormaEvidencijaCijepljenjaDatum.Name = "outputFormaEvidencijaCijepljenjaDatum";
            this.outputFormaEvidencijaCijepljenjaDatum.Size = new System.Drawing.Size(87, 13);
            this.outputFormaEvidencijaCijepljenjaDatum.TabIndex = 12;
            this.outputFormaEvidencijaCijepljenjaDatum.Text = "Datum cijepljenja";
            // 
            // actionFormaEvidencijaCijepljenjaUnesiCijepljenje
            // 
            this.actionFormaEvidencijaCijepljenjaUnesiCijepljenje.Location = new System.Drawing.Point(60, 153);
            this.actionFormaEvidencijaCijepljenjaUnesiCijepljenje.Name = "actionFormaEvidencijaCijepljenjaUnesiCijepljenje";
            this.actionFormaEvidencijaCijepljenjaUnesiCijepljenje.Size = new System.Drawing.Size(163, 41);
            this.actionFormaEvidencijaCijepljenjaUnesiCijepljenje.TabIndex = 11;
            this.actionFormaEvidencijaCijepljenjaUnesiCijepljenje.Text = "Unesi turnus";
            this.actionFormaEvidencijaCijepljenjaUnesiCijepljenje.UseVisualStyleBackColor = true;
            this.actionFormaEvidencijaCijepljenjaUnesiCijepljenje.Click += new System.EventHandler(this.actionFormaEvidencijaCijepljenjaUnesiCijepljenje_Click);
            // 
            // inputFormaEvidencijaCijepljenjaDatum
            // 
            this.inputFormaEvidencijaCijepljenjaDatum.Location = new System.Drawing.Point(30, 115);
            this.inputFormaEvidencijaCijepljenjaDatum.Name = "inputFormaEvidencijaCijepljenjaDatum";
            this.inputFormaEvidencijaCijepljenjaDatum.Size = new System.Drawing.Size(221, 20);
            this.inputFormaEvidencijaCijepljenjaDatum.TabIndex = 10;
            // 
            // inputFormaEvidencijaCijepljenjaCjepivo
            // 
            this.inputFormaEvidencijaCijepljenjaCjepivo.DataSource = this.cjepivoBindingSource;
            this.inputFormaEvidencijaCijepljenjaCjepivo.DisplayMember = "nazivCjepiva";
            this.inputFormaEvidencijaCijepljenjaCjepivo.FormattingEnabled = true;
            this.inputFormaEvidencijaCijepljenjaCjepivo.Location = new System.Drawing.Point(30, 75);
            this.inputFormaEvidencijaCijepljenjaCjepivo.Name = "inputFormaEvidencijaCijepljenjaCjepivo";
            this.inputFormaEvidencijaCijepljenjaCjepivo.Size = new System.Drawing.Size(220, 21);
            this.inputFormaEvidencijaCijepljenjaCjepivo.TabIndex = 14;
            this.inputFormaEvidencijaCijepljenjaCjepivo.ValueMember = "vrstaCjepiva";
            // 
            // cjepivoBindingSource
            // 
            this.cjepivoBindingSource.DataSource = typeof(Cjepivo);
            // 
            // outputFormaEvidencijaCijepljenjaTurnus
            // 
            this.outputFormaEvidencijaCijepljenjaTurnus.AutoSize = true;
            this.outputFormaEvidencijaCijepljenjaTurnus.Location = new System.Drawing.Point(28, 16);
            this.outputFormaEvidencijaCijepljenjaTurnus.Name = "outputFormaEvidencijaCijepljenjaTurnus";
            this.outputFormaEvidencijaCijepljenjaTurnus.Size = new System.Drawing.Size(40, 13);
            this.outputFormaEvidencijaCijepljenjaTurnus.TabIndex = 15;
            this.outputFormaEvidencijaCijepljenjaTurnus.Text = "Turnus";
            // 
            // outputFormaEvidencijaCijepljenjaCjepivo
            // 
            this.outputFormaEvidencijaCijepljenjaCjepivo.AutoSize = true;
            this.outputFormaEvidencijaCijepljenjaCjepivo.Location = new System.Drawing.Point(28, 59);
            this.outputFormaEvidencijaCijepljenjaCjepivo.Name = "outputFormaEvidencijaCijepljenjaCjepivo";
            this.outputFormaEvidencijaCijepljenjaCjepivo.Size = new System.Drawing.Size(42, 13);
            this.outputFormaEvidencijaCijepljenjaCjepivo.TabIndex = 16;
            this.outputFormaEvidencijaCijepljenjaCjepivo.Text = "Cjepivo";
            // 
            // kokosiTurnusBindingSource
            // 
            this.kokosiTurnusBindingSource.DataSource = typeof(KokosiTurnus);
            // 
            // inputFormaEvidencijaCjepljenjaTurnus
            // 
            this.inputFormaEvidencijaCjepljenjaTurnus.Location = new System.Drawing.Point(87, 30);
            this.inputFormaEvidencijaCjepljenjaTurnus.Name = "inputFormaEvidencijaCjepljenjaTurnus";
            this.inputFormaEvidencijaCjepljenjaTurnus.ReadOnly = true;
            this.inputFormaEvidencijaCjepljenjaTurnus.Size = new System.Drawing.Size(100, 20);
            this.inputFormaEvidencijaCjepljenjaTurnus.TabIndex = 17;
            // 
            // FormaEvidencijaCijepljenja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 213);
            this.Controls.Add(this.inputFormaEvidencijaCjepljenjaTurnus);
            this.Controls.Add(this.outputFormaEvidencijaCijepljenjaCjepivo);
            this.Controls.Add(this.outputFormaEvidencijaCijepljenjaTurnus);
            this.Controls.Add(this.inputFormaEvidencijaCijepljenjaCjepivo);
            this.Controls.Add(this.outputFormaEvidencijaCijepljenjaDatum);
            this.Controls.Add(this.actionFormaEvidencijaCijepljenjaUnesiCijepljenje);
            this.Controls.Add(this.inputFormaEvidencijaCijepljenjaDatum);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormaEvidencijaCijepljenja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evidentiranje cijepljenja";
            this.Load += new System.EventHandler(this.FormaEvidencijaCijepljenja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cjepivoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kokosiTurnusBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label outputFormaEvidencijaCijepljenjaDatum;
        private System.Windows.Forms.Button actionFormaEvidencijaCijepljenjaUnesiCijepljenje;
        private System.Windows.Forms.DateTimePicker inputFormaEvidencijaCijepljenjaDatum;
        private System.Windows.Forms.ComboBox inputFormaEvidencijaCijepljenjaCjepivo;
        private System.Windows.Forms.Label outputFormaEvidencijaCijepljenjaTurnus;
        private System.Windows.Forms.Label outputFormaEvidencijaCijepljenjaCjepivo;
        private System.Windows.Forms.BindingSource kokosiTurnusBindingSource;
        private System.Windows.Forms.BindingSource cjepivoBindingSource;
        private System.Windows.Forms.TextBox inputFormaEvidencijaCjepljenjaTurnus;
    }
}