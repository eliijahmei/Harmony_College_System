namespace SistemaColegio
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.btnBoletim = new System.Windows.Forms.Button();
            this.btnMedias = new System.Windows.Forms.Button();
            this.btnAlunos = new System.Windows.Forms.Button();
            this.btnProfessores = new System.Windows.Forms.Button();
            this.btnProvas = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.sair = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.data = new System.Windows.Forms.Label();
            this.hora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBoletim
            // 
            this.btnBoletim.BackColor = System.Drawing.Color.Transparent;
            this.btnBoletim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBoletim.BackgroundImage")));
            this.btnBoletim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBoletim.FlatAppearance.BorderSize = 0;
            this.btnBoletim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoletim.Location = new System.Drawing.Point(382, 229);
            this.btnBoletim.Margin = new System.Windows.Forms.Padding(2);
            this.btnBoletim.Name = "btnBoletim";
            this.btnBoletim.Size = new System.Drawing.Size(120, 120);
            this.btnBoletim.TabIndex = 12;
            this.btnBoletim.UseVisualStyleBackColor = false;
            this.btnBoletim.Click += new System.EventHandler(this.btnBoletim_Click);
            // 
            // btnMedias
            // 
            this.btnMedias.BackColor = System.Drawing.Color.Transparent;
            this.btnMedias.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMedias.BackgroundImage")));
            this.btnMedias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMedias.FlatAppearance.BorderSize = 0;
            this.btnMedias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedias.Location = new System.Drawing.Point(258, 229);
            this.btnMedias.Margin = new System.Windows.Forms.Padding(2);
            this.btnMedias.Name = "btnMedias";
            this.btnMedias.Size = new System.Drawing.Size(120, 120);
            this.btnMedias.TabIndex = 11;
            this.btnMedias.UseVisualStyleBackColor = false;
            this.btnMedias.Click += new System.EventHandler(this.btnMedias_Click);
            // 
            // btnAlunos
            // 
            this.btnAlunos.BackColor = System.Drawing.Color.Transparent;
            this.btnAlunos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAlunos.BackgroundImage")));
            this.btnAlunos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAlunos.FlatAppearance.BorderSize = 0;
            this.btnAlunos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlunos.Location = new System.Drawing.Point(368, 58);
            this.btnAlunos.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlunos.Name = "btnAlunos";
            this.btnAlunos.Size = new System.Drawing.Size(120, 120);
            this.btnAlunos.TabIndex = 10;
            this.btnAlunos.UseVisualStyleBackColor = false;
            this.btnAlunos.Click += new System.EventHandler(this.btnAlunos_Click);
            // 
            // btnProfessores
            // 
            this.btnProfessores.BackColor = System.Drawing.Color.Transparent;
            this.btnProfessores.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProfessores.BackgroundImage")));
            this.btnProfessores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfessores.FlatAppearance.BorderSize = 0;
            this.btnProfessores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfessores.Location = new System.Drawing.Point(122, 58);
            this.btnProfessores.Margin = new System.Windows.Forms.Padding(2);
            this.btnProfessores.Name = "btnProfessores";
            this.btnProfessores.Size = new System.Drawing.Size(120, 120);
            this.btnProfessores.TabIndex = 9;
            this.btnProfessores.UseVisualStyleBackColor = false;
            this.btnProfessores.Click += new System.EventHandler(this.btnProfessores_Click);
            // 
            // btnProvas
            // 
            this.btnProvas.BackColor = System.Drawing.Color.Transparent;
            this.btnProvas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProvas.BackgroundImage")));
            this.btnProvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProvas.FlatAppearance.BorderSize = 0;
            this.btnProvas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProvas.Location = new System.Drawing.Point(134, 229);
            this.btnProvas.Margin = new System.Windows.Forms.Padding(2);
            this.btnProvas.Name = "btnProvas";
            this.btnProvas.Size = new System.Drawing.Size(120, 120);
            this.btnProvas.TabIndex = 8;
            this.btnProvas.UseVisualStyleBackColor = false;
            this.btnProvas.Click += new System.EventHandler(this.btnProvas_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // sair
            // 
            this.sair.BackColor = System.Drawing.Color.Transparent;
            this.sair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sair.BackgroundImage")));
            this.sair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sair.FlatAppearance.BorderSize = 0;
            this.sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sair.Location = new System.Drawing.Point(743, 11);
            this.sair.Margin = new System.Windows.Forms.Padding(2);
            this.sair.Name = "sair";
            this.sair.Size = new System.Drawing.Size(45, 46);
            this.sair.TabIndex = 4;
            this.sair.UseVisualStyleBackColor = false;
            this.sair.Click += new System.EventHandler(this.sair_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(274, 11);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(246, 147);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnAlunos);
            this.panel1.Controls.Add(this.btnMedias);
            this.panel1.Controls.Add(this.btnProfessores);
            this.panel1.Controls.Add(this.btnBoletim);
            this.panel1.Controls.Add(this.btnProvas);
            this.panel1.Location = new System.Drawing.Point(85, 156);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 395);
            this.panel1.TabIndex = 26;
            // 
            // data
            // 
            this.data.AutoSize = true;
            this.data.BackColor = System.Drawing.Color.Transparent;
            this.data.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.data.Location = new System.Drawing.Point(11, 559);
            this.data.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(68, 29);
            this.data.TabIndex = 27;
            this.data.Text = "DATA";
            // 
            // hora
            // 
            this.hora.AutoSize = true;
            this.hora.BackColor = System.Drawing.Color.Transparent;
            this.hora.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hora.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.hora.Location = new System.Drawing.Point(690, 559);
            this.hora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hora.Name = "hora";
            this.hora.Size = new System.Drawing.Size(73, 29);
            this.hora.TabIndex = 28;
            this.hora.Text = "HORA";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(799, 597);
            this.Controls.Add(this.hora);
            this.Controls.Add(this.data);
            this.Controls.Add(this.sair);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPrincipal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colegio Harmonia";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMedias;
        private System.Windows.Forms.Button btnAlunos;
        private System.Windows.Forms.Button btnProfessores;
        private System.Windows.Forms.Button btnProvas;
        private System.Windows.Forms.Button sair;
        private System.Windows.Forms.Button btnBoletim;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label data;
        private System.Windows.Forms.Label hora;
    }
}