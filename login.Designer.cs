
namespace HuzurEviOtomasyonu
{
    partial class login
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
            this.button_giris = new System.Windows.Forms.Button();
            this.button_cikis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_parola = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maskedTextBox_Tc = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.denemeDataSet = new HuzurEviOtomasyonu.denemeDataSet();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denemeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button_giris
            // 
            this.button_giris.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_giris.ForeColor = System.Drawing.Color.Black;
            this.button_giris.Location = new System.Drawing.Point(257, 18);
            this.button_giris.Name = "button_giris";
            this.button_giris.Size = new System.Drawing.Size(82, 42);
            this.button_giris.TabIndex = 0;
            this.button_giris.Text = "Giriş";
            this.button_giris.UseVisualStyleBackColor = false;
            this.button_giris.Click += new System.EventHandler(this.button_giris_Click);
            // 
            // button_cikis
            // 
            this.button_cikis.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_cikis.ForeColor = System.Drawing.Color.Black;
            this.button_cikis.Location = new System.Drawing.Point(356, 18);
            this.button_cikis.Name = "button_cikis";
            this.button_cikis.Size = new System.Drawing.Size(86, 42);
            this.button_cikis.TabIndex = 2;
            this.button_cikis.Text = "Çıkış";
            this.button_cikis.UseVisualStyleBackColor = false;
            this.button_cikis.Click += new System.EventHandler(this.button_cikis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "TC Kimlik No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(51, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parola:";
            // 
            // textBox_parola
            // 
            this.textBox_parola.Location = new System.Drawing.Point(112, 81);
            this.textBox_parola.Name = "textBox_parola";
            this.textBox_parola.PasswordChar = '*';
            this.textBox_parola.Size = new System.Drawing.Size(100, 22);
            this.textBox_parola.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.maskedTextBox_Tc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_cikis);
            this.panel1.Controls.Add(this.button_giris);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_parola);
            this.panel1.Location = new System.Drawing.Point(28, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 148);
            this.panel1.TabIndex = 7;
            // 
            // maskedTextBox_Tc
            // 
            this.maskedTextBox_Tc.Location = new System.Drawing.Point(112, 31);
            this.maskedTextBox_Tc.Mask = "00000000000";
            this.maskedTextBox_Tc.Name = "maskedTextBox_Tc";
            this.maskedTextBox_Tc.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox_Tc.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(163, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(452, 38);
            this.label3.TabIndex = 8;
            this.label3.Text = "HUZUREVİ OTOMASYONU";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HuzurEviOtomasyonu.Properties.Resources.huzurevi_47;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 212);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(804, 401);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(31, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kullanıcı Girişi";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.denemeDataSet;
            this.bindingSource1.Position = 0;
            // 
            // denemeDataSet
            // 
            this.denemeDataSet.DataSetName = "denemeDataSet";
            this.denemeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denemeDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_giris;
        private System.Windows.Forms.Button button_cikis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_parola;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bindingSource1;
        private denemeDataSet denemeDataSet;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Tc;
    }
}