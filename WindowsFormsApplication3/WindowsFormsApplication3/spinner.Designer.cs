namespace WindowsFormsApplication3
{
    partial class spinner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(spinner));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.spinner1 = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timervar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.spinner1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
//            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // spinner1
            // 
            this.spinner1.AnimationSpeed = 0.6F;
            this.spinner1.BaseColor = System.Drawing.Color.Black;
            this.spinner1.Controls.Add(this.timervar);
            this.spinner1.Controls.Add(this.pictureBox1);
            this.spinner1.IdleColor = System.Drawing.Color.OrangeRed;
            this.spinner1.IdleOffset = 23;
            this.spinner1.IdleThickness = 8;
            this.spinner1.Image = null;
            this.spinner1.ImageSize = new System.Drawing.Size(52, 52);
            this.spinner1.Location = new System.Drawing.Point(155, 43);
            this.spinner1.Margin = new System.Windows.Forms.Padding(1);
            this.spinner1.Name = "spinner1";
            this.spinner1.ProgressMaxColor = System.Drawing.Color.White;
            this.spinner1.ProgressMinColor = System.Drawing.Color.White;
            this.spinner1.ProgressOffset = 20;
            this.spinner1.ProgressThickness = 8;
            this.spinner1.Size = new System.Drawing.Size(318, 280);
            this.spinner1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(167, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "Car System Management";
            this.label1.UseMnemonic = false;
//            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timervar
            // 
            this.timervar.AutoSize = true;
            this.timervar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timervar.ForeColor = System.Drawing.SystemColors.Control;
            this.timervar.Location = new System.Drawing.Point(131, 218);
            this.timervar.Name = "timervar";
            this.timervar.Size = new System.Drawing.Size(26, 29);
            this.timervar.TabIndex = 11;
            this.timervar.Text = "0";
            this.timervar.UseMnemonic = false;
            // 
            // spinner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(608, 333);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spinner1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "spinner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.spinner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.spinner1.ResumeLayout(false);
            this.spinner1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaCircleProgressBar spinner1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timervar;
    }
}

