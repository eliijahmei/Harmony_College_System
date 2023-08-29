namespace SistemaColegio.View
{
    partial class FormCadastroProfesor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroProfesor));
            this.data = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.situacao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.novo = new System.Windows.Forms.Button();
            this.editar = new System.Windows.Forms.Button();
            this.salvar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.materia = new System.Windows.Forms.ComboBox();
            this.dataNasc = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sexo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.hora = new System.Windows.Forms.Label();
            this.sair = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.voltar = new System.Windows.Forms.Button();
            this.AlterarLecionando = new System.Windows.Forms.Button();
            this.AlterarNaoLecionando = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // data
            // 
            this.data.AutoSize = true;
            this.data.BackColor = System.Drawing.Color.Transparent;
            this.data.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.data.Location = new System.Drawing.Point(20, 666);
            this.data.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(68, 29);
            this.data.TabIndex = 2;
            this.data.Text = "DATA";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.Color.Linen;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle17;
            this.grid.GridColor = System.Drawing.Color.MistyRose;
            this.grid.Location = new System.Drawing.Point(52, 32);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.grid.RowHeadersWidth = 62;
            this.grid.RowTemplate.Height = 28;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(395, 445);
            this.grid.TabIndex = 5;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCadProfessores_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.grid);
            this.panel2.Location = new System.Drawing.Point(510, 152);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(470, 504);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.AlterarNaoLecionando);
            this.panel1.Controls.Add(this.AlterarLecionando);
            this.panel1.Controls.Add(this.situacao);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.nome);
            this.panel1.Controls.Add(this.id);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.novo);
            this.panel1.Controls.Add(this.editar);
            this.panel1.Controls.Add(this.salvar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.materia);
            this.panel1.Controls.Add(this.dataNasc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.sexo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(25, 152);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 504);
            this.panel1.TabIndex = 6;
            // 
            // situacao
            // 
            this.situacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.situacao.Enabled = false;
            this.situacao.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.situacao.Location = new System.Drawing.Point(225, 33);
            this.situacao.Margin = new System.Windows.Forms.Padding(2);
            this.situacao.Multiline = true;
            this.situacao.Name = "situacao";
            this.situacao.Size = new System.Drawing.Size(129, 23);
            this.situacao.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(120, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "Situação:";
            // 
            // nome
            // 
            this.nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nome.Enabled = false;
            this.nome.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nome.Location = new System.Drawing.Point(133, 185);
            this.nome.Margin = new System.Windows.Forms.Padding(2);
            this.nome.Multiline = true;
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(257, 23);
            this.nome.TabIndex = 18;
            this.nome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nomeProfessor_KeyPress_1);
            // 
            // id
            // 
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id.Enabled = false;
            this.id.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(102, 133);
            this.id.Margin = new System.Windows.Forms.Padding(2);
            this.id.Multiline = true;
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(55, 23);
            this.id.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "ID:";
            // 
            // novo
            // 
            this.novo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("novo.BackgroundImage")));
            this.novo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.novo.FlatAppearance.BorderSize = 0;
            this.novo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.novo.Location = new System.Drawing.Point(102, 428);
            this.novo.Margin = new System.Windows.Forms.Padding(2);
            this.novo.Name = "novo";
            this.novo.Size = new System.Drawing.Size(75, 50);
            this.novo.TabIndex = 11;
            this.novo.UseVisualStyleBackColor = true;
            this.novo.Click += new System.EventHandler(this.novoProfessor_Click);
            // 
            // editar
            // 
            this.editar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editar.BackgroundImage")));
            this.editar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editar.Enabled = false;
            this.editar.FlatAppearance.BorderSize = 0;
            this.editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editar.Location = new System.Drawing.Point(289, 428);
            this.editar.Margin = new System.Windows.Forms.Padding(2);
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(50, 49);
            this.editar.TabIndex = 10;
            this.editar.UseVisualStyleBackColor = true;
            this.editar.Click += new System.EventHandler(this.editarProfessor_Click);
            // 
            // salvar
            // 
            this.salvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salvar.BackgroundImage")));
            this.salvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.salvar.Enabled = false;
            this.salvar.FlatAppearance.BorderSize = 0;
            this.salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salvar.Location = new System.Drawing.Point(206, 428);
            this.salvar.Margin = new System.Windows.Forms.Padding(2);
            this.salvar.Name = "salvar";
            this.salvar.Size = new System.Drawing.Size(50, 49);
            this.salvar.TabIndex = 9;
            this.salvar.UseVisualStyleBackColor = true;
            this.salvar.Click += new System.EventHandler(this.salvarProfessor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 341);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Materia:";
            // 
            // materia
            // 
            this.materia.BackColor = System.Drawing.Color.White;
            this.materia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materia.Enabled = false;
            this.materia.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materia.FormattingEnabled = true;
            this.materia.Location = new System.Drawing.Point(155, 338);
            this.materia.Margin = new System.Windows.Forms.Padding(2);
            this.materia.Name = "materia";
            this.materia.Size = new System.Drawing.Size(123, 28);
            this.materia.TabIndex = 6;
            // 
            // dataNasc
            // 
            this.dataNasc.Enabled = false;
            this.dataNasc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataNasc.Location = new System.Drawing.Point(267, 292);
            this.dataNasc.Margin = new System.Windows.Forms.Padding(2);
            this.dataNasc.Name = "dataNasc";
            this.dataNasc.Size = new System.Drawing.Size(105, 20);
            this.dataNasc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 289);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data de nascimento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sexo:";
            // 
            // sexo
            // 
            this.sexo.BackColor = System.Drawing.Color.White;
            this.sexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexo.Enabled = false;
            this.sexo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sexo.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexo.FormattingEnabled = true;
            this.sexo.Items.AddRange(new object[] {
            "Feminino",
            "Masculino",
            "Outro"});
            this.sexo.Location = new System.Drawing.Point(124, 235);
            this.sexo.Margin = new System.Windows.Forms.Padding(2);
            this.sexo.Name = "sexo";
            this.sexo.Size = new System.Drawing.Size(101, 28);
            this.sexo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(8, 1);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(246, 147);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // hora
            // 
            this.hora.AutoSize = true;
            this.hora.BackColor = System.Drawing.Color.Transparent;
            this.hora.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hora.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.hora.Location = new System.Drawing.Point(881, 666);
            this.hora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hora.Name = "hora";
            this.hora.Size = new System.Drawing.Size(73, 29);
            this.hora.TabIndex = 8;
            this.hora.Text = "HORA";
            // 
            // sair
            // 
            this.sair.BackColor = System.Drawing.Color.Transparent;
            this.sair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sair.BackgroundImage")));
            this.sair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sair.FlatAppearance.BorderSize = 0;
            this.sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sair.Location = new System.Drawing.Point(935, 20);
            this.sair.Margin = new System.Windows.Forms.Padding(2);
            this.sair.Name = "sair";
            this.sair.Size = new System.Drawing.Size(45, 44);
            this.sair.TabIndex = 9;
            this.sair.UseVisualStyleBackColor = false;
            this.sair.Click += new System.EventHandler(this.sairCadProfessor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(586, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // voltar
            // 
            this.voltar.BackColor = System.Drawing.Color.Transparent;
            this.voltar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("voltar.BackgroundImage")));
            this.voltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.voltar.FlatAppearance.BorderSize = 0;
            this.voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.voltar.Location = new System.Drawing.Point(885, 20);
            this.voltar.Margin = new System.Windows.Forms.Padding(2);
            this.voltar.Name = "voltar";
            this.voltar.Size = new System.Drawing.Size(45, 44);
            this.voltar.TabIndex = 11;
            this.voltar.UseVisualStyleBackColor = false;
            this.voltar.Click += new System.EventHandler(this.voltarCadProfessor_Click);
            // 
            // AlterarLecionando
            // 
            this.AlterarLecionando.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AlterarLecionando.BackgroundImage")));
            this.AlterarLecionando.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AlterarLecionando.Enabled = false;
            this.AlterarLecionando.FlatAppearance.BorderSize = 0;
            this.AlterarLecionando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlterarLecionando.Location = new System.Drawing.Point(141, 60);
            this.AlterarLecionando.Margin = new System.Windows.Forms.Padding(2);
            this.AlterarLecionando.Name = "AlterarLecionando";
            this.AlterarLecionando.Size = new System.Drawing.Size(75, 50);
            this.AlterarLecionando.TabIndex = 21;
            this.AlterarLecionando.UseVisualStyleBackColor = true;
            this.AlterarLecionando.Click += new System.EventHandler(this.AlterarLecionando_Click);
            // 
            // AlterarNaoLecionando
            // 
            this.AlterarNaoLecionando.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AlterarNaoLecionando.BackgroundImage")));
            this.AlterarNaoLecionando.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AlterarNaoLecionando.Enabled = false;
            this.AlterarNaoLecionando.FlatAppearance.BorderSize = 0;
            this.AlterarNaoLecionando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlterarNaoLecionando.Location = new System.Drawing.Point(265, 60);
            this.AlterarNaoLecionando.Margin = new System.Windows.Forms.Padding(2);
            this.AlterarNaoLecionando.Name = "AlterarNaoLecionando";
            this.AlterarNaoLecionando.Size = new System.Drawing.Size(75, 50);
            this.AlterarNaoLecionando.TabIndex = 22;
            this.AlterarNaoLecionando.UseVisualStyleBackColor = true;
            this.AlterarNaoLecionando.Click += new System.EventHandler(this.AlterarNaoLecionando_Click);
            // 
            // FormCadastroProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1005, 699);
            this.Controls.Add(this.voltar);
            this.Controls.Add(this.sair);
            this.Controls.Add(this.hora);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.data);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCadastroProfesor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de professores";
            this.Load += new System.EventHandler(this.FormCadProfesor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label data;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label hora;
        private System.Windows.Forms.Button sair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button salvar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox materia;
        private System.Windows.Forms.DateTimePicker dataNasc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button novo;
        private System.Windows.Forms.Button editar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button voltar;
        private System.Windows.Forms.ComboBox sexo;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox situacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AlterarNaoLecionando;
        private System.Windows.Forms.Button AlterarLecionando;
    }
}