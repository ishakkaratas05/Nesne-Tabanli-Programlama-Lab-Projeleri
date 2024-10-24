namespace Flappy_Bird_Game
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ucanKus = new System.Windows.Forms.PictureBox();
            this.üsttekiBoru = new System.Windows.Forms.PictureBox();
            this.alttakiBoru = new System.Windows.Forms.PictureBox();
            this.Zemin = new System.Windows.Forms.PictureBox();
            this.skorMetni = new System.Windows.Forms.Label();
            this.oyunSayaci = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ucanKus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.üsttekiBoru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alttakiBoru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zemin)).BeginInit();
            this.SuspendLayout();
            // 
            // ucanKus
            // 
            this.ucanKus.Image = ((System.Drawing.Image)(resources.GetObject("ucanKus.Image")));
            this.ucanKus.Location = new System.Drawing.Point(75, 123);
            this.ucanKus.Name = "ucanKus";
            this.ucanKus.Size = new System.Drawing.Size(80, 64);
            this.ucanKus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ucanKus.TabIndex = 0;
            this.ucanKus.TabStop = false;
            // 
            // üsttekiBoru
            // 
            this.üsttekiBoru.Image = ((System.Drawing.Image)(resources.GetObject("üsttekiBoru.Image")));
            this.üsttekiBoru.Location = new System.Drawing.Point(392, -23);
            this.üsttekiBoru.Name = "üsttekiBoru";
            this.üsttekiBoru.Size = new System.Drawing.Size(100, 175);
            this.üsttekiBoru.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.üsttekiBoru.TabIndex = 0;
            this.üsttekiBoru.TabStop = false;
            this.üsttekiBoru.Click += new System.EventHandler(this.üsttekiBoru_Click);
            // 
            // alttakiBoru
            // 
            this.alttakiBoru.Image = ((System.Drawing.Image)(resources.GetObject("alttakiBoru.Image")));
            this.alttakiBoru.Location = new System.Drawing.Point(392, 418);
            this.alttakiBoru.Name = "alttakiBoru";
            this.alttakiBoru.Size = new System.Drawing.Size(100, 175);
            this.alttakiBoru.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.alttakiBoru.TabIndex = 0;
            this.alttakiBoru.TabStop = false;
            // 
            // Zemin
            // 
            this.Zemin.Image = ((System.Drawing.Image)(resources.GetObject("Zemin.Image")));
            this.Zemin.Location = new System.Drawing.Point(-7, 587);
            this.Zemin.Name = "Zemin";
            this.Zemin.Size = new System.Drawing.Size(746, 69);
            this.Zemin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Zemin.TabIndex = 0;
            this.Zemin.TabStop = false;
            this.Zemin.Click += new System.EventHandler(this.Zemin_Click);
            // 
            // skorMetni
            // 
            this.skorMetni.AutoSize = true;
            this.skorMetni.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.skorMetni.Location = new System.Drawing.Point(12, 659);
            this.skorMetni.Name = "skorMetni";
            this.skorMetni.Size = new System.Drawing.Size(194, 28);
            this.skorMetni.TabIndex = 1;
            this.skorMetni.Text = "Oyun Skoru : 0";
            this.skorMetni.Click += new System.EventHandler(this.label1_Click);
            // 
            // oyunSayaci
            // 
            this.oyunSayaci.Enabled = true;
            this.oyunSayaci.Interval = 20;
            this.oyunSayaci.Tick += new System.EventHandler(this.oyunSayaciOlaylari);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(734, 695);
            this.Controls.Add(this.ucanKus);
            this.Controls.Add(this.skorMetni);
            this.Controls.Add(this.Zemin);
            this.Controls.Add(this.alttakiBoru);
            this.Controls.Add(this.üsttekiBoru);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.asagiOyunTusu);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.yukariOyunTusu);
            ((System.ComponentModel.ISupportInitialize)(this.ucanKus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.üsttekiBoru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alttakiBoru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zemin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ucanKus;
        private System.Windows.Forms.PictureBox üsttekiBoru;
        private System.Windows.Forms.PictureBox alttakiBoru;
        private System.Windows.Forms.PictureBox Zemin;
        private System.Windows.Forms.Label skorMetni;
        private System.Windows.Forms.Timer oyunSayaci;
    }
}

