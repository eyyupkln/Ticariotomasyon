namespace Ticariotomasyon
{
    partial class frmadmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmadmin));
            this.txtkullanıcıad = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtşifre = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btngirşyap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtkullanıcıad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtşifre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtkullanıcıad
            // 
            this.txtkullanıcıad.Location = new System.Drawing.Point(414, 108);
            this.txtkullanıcıad.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtkullanıcıad.Name = "txtkullanıcıad";
            this.txtkullanıcıad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkullanıcıad.Properties.Appearance.Options.UseFont = true;
            this.txtkullanıcıad.Size = new System.Drawing.Size(338, 34);
            this.txtkullanıcıad.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(162, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kullanıcı adı:";
            // 
            // txtşifre
            // 
            this.txtşifre.Location = new System.Drawing.Point(414, 179);
            this.txtşifre.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtşifre.Name = "txtşifre";
            this.txtşifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtşifre.Properties.Appearance.Options.UseFont = true;
            this.txtşifre.Properties.UseSystemPasswordChar = true;
            this.txtşifre.Size = new System.Drawing.Size(338, 34);
            this.txtşifre.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(162, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Şifre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(335, 470);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(444, 61);
            this.label3.TabIndex = 7;
            this.label3.Text = "TİCARİ OTOMASYON";
            // 
            // btngirşyap
            // 
            this.btngirşyap.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btngirşyap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngirşyap.Location = new System.Drawing.Point(414, 249);
            this.btngirşyap.Name = "btngirşyap";
            this.btngirşyap.Size = new System.Drawing.Size(338, 65);
            this.btngirşyap.TabIndex = 8;
            this.btngirşyap.Text = "Giriş Yap";
            this.btngirşyap.UseVisualStyleBackColor = false;
            this.btngirşyap.Click += new System.EventHandler(this.btngirşyap_Click);
            this.btngirşyap.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.btngirşyap.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // frmadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1113, 530);
            this.Controls.Add(this.btngirşyap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtşifre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtkullanıcıad);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmadmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GİRİŞ ";
            ((System.ComponentModel.ISupportInitialize)(this.txtkullanıcıad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtşifre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtkullanıcıad;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtşifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btngirşyap;
    }
}