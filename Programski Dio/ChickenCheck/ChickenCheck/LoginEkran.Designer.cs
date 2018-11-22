namespace ChickenCheck
{
    partial class LoginEkran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginEkran));
            this.inputLoginEkranKorisnickoIme = new System.Windows.Forms.TextBox();
            this.inputLoginEkranLozinka = new System.Windows.Forms.TextBox();
            this.outputLoginEkranKorisnickoIme = new System.Windows.Forms.Label();
            this.outputLoginEkranLozinka = new System.Windows.Forms.Label();
            this.actionLoginEkranPrijava = new System.Windows.Forms.Button();
            this.outputLoginEkranGreskePrijavljivanja = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputLoginEkranKorisnickoIme
            // 
            this.inputLoginEkranKorisnickoIme.Location = new System.Drawing.Point(136, 152);
            this.inputLoginEkranKorisnickoIme.Name = "inputLoginEkranKorisnickoIme";
            this.inputLoginEkranKorisnickoIme.Size = new System.Drawing.Size(169, 20);
            this.inputLoginEkranKorisnickoIme.TabIndex = 0;
            // 
            // inputLoginEkranLozinka
            // 
            this.inputLoginEkranLozinka.Location = new System.Drawing.Point(136, 175);
            this.inputLoginEkranLozinka.Name = "inputLoginEkranLozinka";
            this.inputLoginEkranLozinka.PasswordChar = '*';
            this.inputLoginEkranLozinka.Size = new System.Drawing.Size(169, 20);
            this.inputLoginEkranLozinka.TabIndex = 1;
            // 
            // outputLoginEkranKorisnickoIme
            // 
            this.outputLoginEkranKorisnickoIme.AutoSize = true;
            this.outputLoginEkranKorisnickoIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLoginEkranKorisnickoIme.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.outputLoginEkranKorisnickoIme.Location = new System.Drawing.Point(32, 152);
            this.outputLoginEkranKorisnickoIme.Name = "outputLoginEkranKorisnickoIme";
            this.outputLoginEkranKorisnickoIme.Size = new System.Drawing.Size(98, 16);
            this.outputLoginEkranKorisnickoIme.TabIndex = 2;
            this.outputLoginEkranKorisnickoIme.Text = "Korisničko ime:";
            // 
            // outputLoginEkranLozinka
            // 
            this.outputLoginEkranLozinka.AutoSize = true;
            this.outputLoginEkranLozinka.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLoginEkranLozinka.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.outputLoginEkranLozinka.Location = new System.Drawing.Point(73, 175);
            this.outputLoginEkranLozinka.Name = "outputLoginEkranLozinka";
            this.outputLoginEkranLozinka.Size = new System.Drawing.Size(57, 16);
            this.outputLoginEkranLozinka.TabIndex = 3;
            this.outputLoginEkranLozinka.Text = "Lozinka:";
            // 
            // actionLoginEkranPrijava
            // 
            this.actionLoginEkranPrijava.BackColor = System.Drawing.Color.Peru;
            this.actionLoginEkranPrijava.FlatAppearance.BorderSize = 0;
            this.actionLoginEkranPrijava.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Peru;
            this.actionLoginEkranPrijava.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tan;
            this.actionLoginEkranPrijava.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.actionLoginEkranPrijava.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLoginEkranPrijava.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.actionLoginEkranPrijava.Location = new System.Drawing.Point(139, 206);
            this.actionLoginEkranPrijava.Name = "actionLoginEkranPrijava";
            this.actionLoginEkranPrijava.Size = new System.Drawing.Size(113, 35);
            this.actionLoginEkranPrijava.TabIndex = 4;
            this.actionLoginEkranPrijava.Text = "Prijavi se";
            this.actionLoginEkranPrijava.UseVisualStyleBackColor = false;
            this.actionLoginEkranPrijava.Click += new System.EventHandler(this.actionLoginEkranPrijava_Click);
            // 
            // outputLoginEkranGreskePrijavljivanja
            // 
            this.outputLoginEkranGreskePrijavljivanja.AutoSize = true;
            this.outputLoginEkranGreskePrijavljivanja.Location = new System.Drawing.Point(37, 238);
            this.outputLoginEkranGreskePrijavljivanja.Name = "outputLoginEkranGreskePrijavljivanja";
            this.outputLoginEkranGreskePrijavljivanja.Size = new System.Drawing.Size(0, 13);
            this.outputLoginEkranGreskePrijavljivanja.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(86, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // LoginEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(375, 260);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.outputLoginEkranGreskePrijavljivanja);
            this.Controls.Add(this.actionLoginEkranPrijava);
            this.Controls.Add(this.outputLoginEkranLozinka);
            this.Controls.Add(this.outputLoginEkranKorisnickoIme);
            this.Controls.Add(this.inputLoginEkranLozinka);
            this.Controls.Add(this.inputLoginEkranKorisnickoIme);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChickenCheck - Prijava";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputLoginEkranKorisnickoIme;
        private System.Windows.Forms.TextBox inputLoginEkranLozinka;
        private System.Windows.Forms.Label outputLoginEkranKorisnickoIme;
        private System.Windows.Forms.Label outputLoginEkranLozinka;
        private System.Windows.Forms.Button actionLoginEkranPrijava;
        private System.Windows.Forms.Label outputLoginEkranGreskePrijavljivanja;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}